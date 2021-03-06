﻿using HızlıTrenApp.DAL.Repository.Abstract;
using HızlıTrenApp.DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HızlıTrenApp.DAL.Repository.Concrete
{
    public class SeferlerSeferSaatleriDal
    {
        private IRepository<SeferSeferSaat> _seferSeferSaatRepository;
        private DbContext _dbContext;

        public SeferlerSeferSaatleriDal()
        {
            _dbContext = new Context();
            _seferSeferSaatRepository = new EFRepository<SeferSeferSaat>(_dbContext);
        }

        public List<SeferSeferSaat> GetBySeferID(int id)
        {
            using (Context db = new Context())
            {
                return db.SeferSeferSaat.Where(x => x.SeferID == id).ToList();
            }
        }

        public int GetBySeferIdAndSaatId(int seferID, int saatID)
        {
            return _seferSeferSaatRepository.GetAll().Where(x => x.SeferID == seferID && x.SeferSaatID == saatID).Select(x => x.ID).FirstOrDefault();
        }
        public void Add(List<SeferSeferSaat> seferSeferSaat)
        {
            using (Context db = new Context())
            {
                db.SeferSeferSaat.AddRange(seferSeferSaat);
                db.SaveChanges();
            }
        }


    }
}
