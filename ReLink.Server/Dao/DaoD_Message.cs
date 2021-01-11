using ReLink.Server.Common;
using ReLink.Server.DB;
using ReLink.Server.Entiy.DbEntity;
using System.Collections.Generic;
using System.Linq;

namespace ReLink.Server.Dao
{
    public class DaoD_Message : Framework.DaoBase
    {
        public List<D_MessageEntity> GetList(int groupId)
        {
            return this.context.CellEntitys.Where(m => m.GroupId == groupId).ToList();
        }

        public void Save(D_MessageEntity data)
        {
            using (AppDbContext contexForSave = Context.CreateAppDbContextForSave(true))
            {
                contexForSave.Entry(data).State = ConvertEnmEditModeToEntityState(EnmEditMode.Insert);
                contexForSave.SaveChanges();
            }
        }
    }
}
