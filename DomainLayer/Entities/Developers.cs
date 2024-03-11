using DomainLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Developers
    {
        /*public IUnitOfWork unitOfWork { get; set; }
            public Developers(IUnitOfWork _unitOfWork)
            {
                unitOfWork = _unitOfWork;
            }
            public void testData()
            {
                unitOfWork.project.GetAllIncludes().ToList();
            }*/
        public int Id { get; set; }
        public string Name { get; set; }
        public int Followers { get; set; }
    }
}
