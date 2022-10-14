using DMS.Data;
using DMS.Interfaces;
using DMS.Models;

namespace DMS.Services
{
    public class KPService : IKPService
    {
        private readonly ApplicationDBContext _db;
        public KPService(ApplicationDBContext db)
        {
            _db = db;
        }

        public AppResponse AddKnowledgePool(string KPName)
        {
            KnowledgePool KP = new KnowledgePool();
            AppResponse response = new AppResponse();
            int count = _db.KnowledgePools.Where(s => s.Name.ToLower() == KPName.ToLower()).Count();
            if (count > 0)
            {
                response.title = "Knowledge Pool Already Exists.";
                response.response = false;
                return response;
            }
            KP.Name = KPName;
            KP.CreationDate = DateTime.Now;
            try
            {
                _db.KnowledgePools.Add(KP);
                _db.SaveChanges();
                response.response = true;
                response.title = "Knowledge Pool Added Succefuly.";
            }
            catch (Exception E)
            {
                response.response = false;
                response.title = E.Message;
                response.stacktrace = E.StackTrace;
                return response;
            }

            return response;



        }
        public AppResponse UpdateKnowledgePool(string OldName, string NewName)
        {
            KnowledgePool KP = new KnowledgePool();
            AppResponse response = new AppResponse();

            KP=_db.KnowledgePools.Where(s=>s.Name.ToLower()==OldName.ToLower()).FirstOrDefault();
            if(KP is null)
            {
                response.title = "Knowledge Pool "+OldName+" Doesn't Exists.";
                response.response = false;
                return response;
            }
            else
            {
                try
                {
                    KP.Name = NewName;
                    _db.KnowledgePools.Update(KP);
                    _db.SaveChanges();
                    response.response = true;
                    response.title = "Knowledge Pool Updated Succefuly.";
                    return response;
                }
                catch (Exception E)
                {
                    response.response = false;
                    response.title = E.Message;
                    response.stacktrace = E.StackTrace;
                    return response;
                }
            }

        }
        public AppResponse DeleteKnowledgePool(string KPName)
        {
            KnowledgePool KP = new KnowledgePool();
            AppResponse response = new AppResponse();
            int count = _db.KnowledgePools.Where(s => s.Name.ToLower() == KPName.ToLower()).Count();
            if (count <= 0)
            {
                response.title = "Knowledge Pool Doesn't Exists.";
                response.response = false;
                return response;
            }
            KP = _db.KnowledgePools.Where(s => s.Name.ToLower() == KPName.ToLower()).First();
            try
            {
                _db.KnowledgePools.Remove(KP);
                _db.SaveChanges();
                response.response = true;
                response.title = "Knowledge Pool removed Succefuly.";
            }
            catch (Exception E)
            {
                response.response = false;
                response.title = E.Message;
                response.stacktrace = E.StackTrace;
                return response;
            }

            return response;

        }
        public List<KnowledgePool> ListKnowledgePools()
        {
            List<KnowledgePool> KnowledgePools = new List<KnowledgePool>();
            KnowledgePools = _db.KnowledgePools.ToList();
            if(KnowledgePools is null)
            {
                KnowledgePools = new List<KnowledgePool>();
            }
            return KnowledgePools;
        }
    }
}
