using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Ticketing.Entity.TicketModel;
using Ticketing.Identity;


namespace Ticketing.Data.Repository
{
    public interface IDepartmentRepository
    {
        ICollection<Department> GetAll();
        Department AddADepartment(Department model);
        void AddADegreePorgram(DegreeProgram model, Guid DepId);
        void AddASpecialization(Specialization model, Guid DegreeProgramID);
        DegreeProgram GetADgreeProgram(Guid DepId, string ProgramName);
        ICollection<DegreeType> GetAllDegreeTypes();
        object AddSpecializationForSupervisor(Guid guid, object supRecID, string v, object userRecID);
        ICollection<DegreeProgram> GetAllDegreeProgramsByID(string degreeType);
        SupervisorDegreeProgram AddSpecializationForSupervisor(Guid SpecializationRecID, string userRecID);
        DegreeType GetADegreeTypeByName(string degreeType);
        ICollection<Specialization> GetSpcializationByDegreeProgramID(string degreeProgramID);
        ICollection<SupervisorDegreeProgram> GetSpecializationsByUserRecID(string userRecID);
        ICollection<SupervisorDegreeProgram> UpdateSpcializationsByUserRecID(string userRecID, ICollection<string> specializations);
        ICollection<SupervisorDegreeProgram> getSuperVisorSpecialzation(string userRecID);
        ICollection<ApplicationUser> GetSuperVisorBySpecialization(string specialization);
        ICollection<ApplicationUser> GetAllSupervisors();
        DegreeType GetDegreeTypeById(Guid guid);
        DegreeProgram GetDegreeProgramByID(Guid guid);
        Specialization GetSpecializationById(Guid guid);
    }
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddADegreePorgram(DegreeProgram model, Guid DepId)
        {

            _context.Departments.Find(DepId).DegreePrograms.Add(model);
        }

        public Department AddADepartment(Department model)
        {
            return _context.Departments.Add(model);
        }

        public void AddASpecialization(Specialization model, Guid DegreeProgramID)
        {
            _context.DegreePrograms.Find(DegreeProgramID).Specializations.Add(model);
        }

        public object AddSpecializationForSupervisor(Guid guid, object supRecID, string v, object userRecID)
        {
            throw new NotImplementedException();
        }

        public SupervisorDegreeProgram AddSpecializationForSupervisor(Guid SpecializationRecID, string userRecID)
        {
            var model = new SupervisorDegreeProgram
            {
                Specialization = _context.Specializations.Find(SpecializationRecID),
                Supervisor = _context.Users.Find(userRecID)
            };
            return _context.SupervisorDegreePrograms.Add(model);



        }

        public DegreeType GetADegreeTypeByName(string degreeType)
        {
            return _context.DegreeTypes.Where(d => d.Name.Equals(degreeType)).FirstOrDefault();
        }

        public DegreeProgram GetADgreeProgram(Guid DepId, string ProgramName)
        {
            var m = _context.Departments.Find(DepId);
            return m.DegreePrograms.Where(d => d.Name.Equals(ProgramName)).FirstOrDefault();
        }

        public ICollection<Department> GetAll()
        {
            _context.SystemSettings.Add(new SystemSettings() { Key = "ServerName", Value = "Student.com" });
            _context.SaveChanges();
            var model = _context.Departments
                .Include(d => d.DegreePrograms.Select(s => s.Specializations))
                .ToList();
            return model;
        }

        public ICollection<DegreeProgram> GetAllDegreeProgramsByID(string degreeType)
        {
            return _context.DegreePrograms.Where(x => x.DegreeType.Recid.Equals(new Guid(degreeType))).ToList();
        }

        public ICollection<DegreeType> GetAllDegreeTypes()
        {
            return _context.DegreeTypes.ToList();

        }


        public ICollection<Specialization> GetSpcializationByDegreeProgramID(string degreeProgramID)
        {
            return _context.Specializations.Where(d => d.DegreePrograms.RecID.Equals(new Guid(degreeProgramID))).ToList();
        }

        public ICollection<SupervisorDegreeProgram> GetSpecializationsByUserRecID(string userRecID)
        {
            return _context.SupervisorDegreePrograms.Where(x => x.Supervisor.Equals(userRecID)).ToList();
        }

        public ICollection<ApplicationUser> GetSuperVisorBySpecialization(string specialization)
        {
            var UsersIDs = _context.SupervisorDegreePrograms.Where(x => x.Specialization.RecID.Equals(new Guid(specialization))).Select(x=> x.Supervisor.Id).ToList();
            return _context.Users.Where(u => UsersIDs.Contains(u.Id)).ToList();
        }


        public ICollection<ApplicationUser> GetAllSupervisors()
        {
            var UsersIDs = _context.SupervisorDegreePrograms.Select(x => x.Supervisor.Id).ToList();
            return _context.Users.Where(u => UsersIDs.Contains(u.Id)).ToList();

            
        }


        public ICollection<SupervisorDegreeProgram> getSuperVisorSpecialzation(string userRecID)
        {
            return _context.SupervisorDegreePrograms.Where(x => x.Supervisor.Id.Equals(userRecID)).ToList();
        }

        public ICollection<SupervisorDegreeProgram> UpdateSpcializationsByUserRecID(string userRecID, ICollection<string> specializations)
        {

            var ToBeRemoved = _context.SupervisorDegreePrograms.Where(x => x.Supervisor.Id.Equals(userRecID));
            var removed = _context.SupervisorDegreePrograms.RemoveRange(ToBeRemoved);


            ////Get all the spcializations that the user has selected
            var ToBeAdded = _context.Specializations.Where(s => specializations.Contains(s.RecID.ToString())).ToList();


            ICollection<SupervisorDegreeProgram> result = new List<SupervisorDegreeProgram>();
            foreach (var item in specializations)
            {
                result.Add(
                    _context.SupervisorDegreePrograms.Add(new SupervisorDegreeProgram()
                    {
                        Specialization = _context.Specializations.Find(new Guid(item)),
                        Supervisor = _context.Users.Find(userRecID)
                    })
                );
            }
            return result;

            return _context.SupervisorDegreePrograms.AddRange(
                ToBeAdded.Select(x => new SupervisorDegreeProgram()
                {
                    Specialization = x,
                    Supervisor = _context.Users.Find(userRecID)

                }).ToList()
                ).ToList();
        }

        public DegreeType GetDegreeTypeById(Guid guid)
        {
           return _context.DegreeTypes.Where(x => x.Recid.Equals(guid)).FirstOrDefault();
        }

        public DegreeProgram GetDegreeProgramByID(Guid guid)
        {
            return _context.DegreePrograms.Where(x => x.RecID.Equals(guid)).FirstOrDefault();
        }

        public Specialization GetSpecializationById(Guid guid)
        {
            return _context.Specializations.Where(x => x.RecID.Equals(guid)).FirstOrDefault();
        }
    }
}