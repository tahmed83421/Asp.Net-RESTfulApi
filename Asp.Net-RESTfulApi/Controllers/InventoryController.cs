using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Asp.Net_RESTfulApi.Models;

namespace Asp.Net_RESTfulApi.Controllers
{
    
    
    public class InventoryController : ApiController
    {
        KSAEntities1 db = new KSAEntities1();
        [HttpGet]
        public IEnumerable<VehiclePart> vehicleParts()
        {
            return db.VehicleParts.ToList();
        }
        [HttpGet]
        public VehiclePart vehiclePartsById(int id)
        {
            
            return db.VehicleParts.SingleOrDefault(x => x.PartID == id);
        }
        public void deleteParts(int id)
        {
            db.VehicleParts.Remove(db.VehicleParts.Find(id));
        }


    }
}
