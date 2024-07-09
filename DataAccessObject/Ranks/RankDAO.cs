using Azure.Core;
using BusinessObject;
using BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Ranks
{
    public class RankDAO
    {
        private readonly MilkTeaDeliveryDBContext _context;
        public RankDAO(MilkTeaDeliveryDBContext context)
        {
            this._context = context;
        }
        public string AddRank(Rank request)
        {
            try
            {
                if (request == null)
                    return "fail";
                if ((this._context.Ranks.Where(x => x.rankName.Equals(request.rankName) && x.delete_At == null).FirstOrDefault()) != null)
                    return "Duplicate rank";
                this._context.Ranks.Add(request);
                this._context.SaveChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        public string RemoveRank(int request) 
        {
            try
            {
                var rank = this._context.Ranks.Where(x => x.rankID.Equals(request) && x.delete_At == null).FirstOrDefault();
                if (rank == null)
                    return "not found";
                rank.delete_At = DateTime.UtcNow;
                this._context.Ranks.Update(rank);
                this._context.SaveChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        public Rank GetRank(int request) 
        {
            try
            {
                return this._context.Ranks.Where(x => x.rankID.Equals(request) && x.delete_At == null).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        public List<Rank> GetAllRanks() 
        {
            try
            {
                return this._context.Ranks.Where(x => x.delete_At == null).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        public string UpdateRank(Rank request) 
        {
            try
            {
                if (request == null)
                    return "fail";
                var rank = this._context.Ranks.Where(x => x.rankID.Equals(request) && x.delete_At == null).FirstOrDefault();
                if (rank == null) 
                    return "Not found";
                this._context.Ranks.Update(request);
                this._context.SaveChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}
