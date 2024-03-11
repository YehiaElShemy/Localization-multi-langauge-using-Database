using DomainLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Projects
    {
        private readonly IUnitOfWork unitOfWork;
        public Projects()
        {
            
        }
        public Projects(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            
          
        }
        public void text()
        {
            Task
            Projects projects = new Projects();
            var res = unitOfWork.project.CreateAsync(projects);

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
