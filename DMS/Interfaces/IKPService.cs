using DMS.Models;

namespace DMS.Interfaces
{
    public interface IKPService
    {
        AppResponse AddKnowledgePool(string KPName);
        AppResponse UpdateKnowledgePool(string OldName,string NewName);
        AppResponse DeleteKnowledgePool(string KPName);
        List<KnowledgePool>  ListKnowledgePools();
    }
}