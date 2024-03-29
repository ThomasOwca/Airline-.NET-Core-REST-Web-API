﻿using Airline_Web_API.Data;
using Airline_Web_API.Models.Entities;
using Airline_Web_API.Models.ServiceModels.FleetServiceModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_Web_API.Services.FleetService
{
    public class FleetService : IFleet
    {
        private readonly ApplicationDbContext _context;

        public FleetService(ApplicationDbContext context)
        {
            _context = context;
        }

        public DeleteAircraftInFleetResponse DeleteAircraftInFleet(DeleteAircraftInFleetRequest request)
        {
            var response = new DeleteAircraftInFleetResponse
            {
                IsSuccessful = false,
                Message = ""
            };

            try
            {
                var aircraft = _context.Fleet
                    .Include(plane => plane.Aircraft)
                    .Include(plane => plane.Status)
                    .FirstOrDefault(plane => plane.Id == request.FleetInventoryId);

                _context.Remove(aircraft);
                _context.SaveChanges();

                response.IsSuccessful = true;
                response.Message = "Aircraft removed from fleet successfully.";
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public GetFleetResponse GetFleet(GetFleetRequest request)
        {
            var response = new GetFleetResponse
            {
                IsSuccessful = false,
                Message = "",
            };

            try
            {
                var aircraft = _context.Fleet
                    .Include(plane => plane.Aircraft)
                    .Include(plane => plane.Status)
                    .ToList();

                if (aircraft != null && aircraft.Count != 0)
                {
                    response.IsSuccessful = true;
                    response.Message = "The airline fleet was found.";
                    response.AirlineAircraft = aircraft;
                }
                else
                {
                    response.IsSuccessful = false;
                    response.Message = "The airline fleet was not found.";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public GetFleetByAircraftIdResponse GetFleetByAircraftId(GetFleetByAircraftIdRequest request)
        {
            var response = new GetFleetByAircraftIdResponse
            {
                IsSuccessful = false,
                Message = "",
            };

            try
            {
                var aircraft = _context.Fleet
                    .Include(plane => plane.Aircraft)
                    .Include(plane => plane.Status)
                    .Where(plane => plane.Aircraft.Id == request.AircraftId)
                    .ToList();

                if (aircraft != null)
                {
                    response.IsSuccessful = true;
                    response.Message = "The airline fleet was found.";
                    response.AirlineAircraft = aircraft;
                }
                else
                {
                    response.IsSuccessful = false;
                    response.Message = "The airline fleet was not found.";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public PostAircraftToFleetResponse PostAircraftToFleet(PostAircraftToFleetRequest request)
        {
            var response = new PostAircraftToFleetResponse
            {
                IsSuccessful = false,
                Message = "",
            };

            Aircraft aircraft = new Aircraft();

            if (request.Aircraft.Id > 0)
                aircraft = _context.Aircraft.FirstOrDefault(plane => plane.Id == request.Aircraft.Id);
            else
            {
                response.Message = "This aircraft does not exist as a type for the airline.";
                return response;
            }


            var newInventoryItemForFleet = new Fleet
            {
                Aircraft = aircraft,
                Status = _context.AircraftStatuses.FirstOrDefault(status => status.Id == 1)
            };

            try
            {
                _context.Fleet.Add(newInventoryItemForFleet);
                _context.SaveChanges();

                response.IsSuccessful = true;
                response.Message = "Aircraft added to fleet inventory.";
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public PutAircraftInFleetResponse PutAircraftInFleet(PutAircraftInFleetRequest request)
        {
            var response = new PutAircraftInFleetResponse
            {
                IsSuccessful = false,
                Message = "",
            };
            
            try
            {
                Fleet fleetItem;

                if (request.Id > 0)
                {
                    fleetItem = _context.Fleet
                    .Include(item => item.Aircraft)
                    .Include(item => item.Status)
                    .FirstOrDefault(item => item.Id == request.Id);
                }
                else
                {
                    fleetItem = new Fleet();
                }
                
                //_context.Update(request.Id);

                // Might need additional logic if the aircraft is existing type that already exists.
                // Same for the status.
                if (request.Aircraft.Id > 0)
                {
                    request.Aircraft = _context.Aircraft.FirstOrDefault(aircraft => aircraft.Id == request.Aircraft.Id);
                }

                if (request.Status.Id > 0)
                {
                    request.Status = _context.AircraftStatuses.FirstOrDefault(status => status.Id == request.Status.Id);
                }

                fleetItem.Aircraft = request.Aircraft;
                fleetItem.Status = request.Status;
                fleetItem.PurchaseDate = DateTime.Now;

                // This should probably work, unless one of the Aircraft or Status entities are a new
                // type that don't already exist.
                _context.Update(fleetItem);
                _context.SaveChanges();

                response.IsSuccessful = true;
                response.Message = "Aircraft updated in fleet inventory.";

            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = ex.Message;
            }
            

            return response;
        }

    }
}
