using System.Collections;
using W.Model;
namespace W.IDAL
{
    public interface IDepartmentDao
    {
        Department FindById(string  departmentId);
        void Delete(Department  department);
        Department Save(Department  department);
        Department SaveOrUpdate(Department department);
        IList FindAll();
    }
}
