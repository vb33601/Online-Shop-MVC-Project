﻿using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CityRepository:BaseRepository<City>
    {
        public CityRepository(OnlineShopEntities context) : base(context)
        {
        }

        public override void Save(City city)
        {
            if (city.ID == 0)
            {
                base.Create(city);
            }
            else
            {
                base.Update(city, item => item.ID == city.ID);
            }
        }
    }
}
