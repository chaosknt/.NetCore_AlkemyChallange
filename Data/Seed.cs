using AlkemyChallange.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyChallange.Data
{
    public class Seed
    {
        private const string adminDNI = "15.331.297";
        private const string adminDocket = "DD15.331.297";
        private const string studentDNI = "45.331.297";
        private const string studentDocket = "ST45.331.297";
        private const string rolAdmin = RolesName.Administrador;
        private const string rolStudent = RolesName.Estudiante;

        public static void Start(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<Context>();
                context.Database.EnsureCreated();

                var _usermgr = serviceScope.ServiceProvider.GetService<UserManager<UserAcc>>();
                var _rolmgr = serviceScope.ServiceProvider.GetService<RoleManager<Role>>();

                var roles = context.Role.ToList();                

                if(roles.Count <= 0)
                {
                    var rol1 = _rolmgr.CreateAsync(new Role { Name = RolesName.Administrador }).Result;
                    var rol2 = _rolmgr.CreateAsync(new Role { Name = RolesName.Estudiante }).Result;
                }

                var days = context.DayOfTheWeek.ToList();

                DayOfTheWeek lunes = null;
                DayOfTheWeek martes = null;
                DayOfTheWeek miercoles = null;
                DayOfTheWeek jueves = null;
                DayOfTheWeek viernes = null;
                DayOfTheWeek sabado = null;
                DayOfTheWeek domingo = null;

                if (days.Count <= 0)
                {
                    lunes = new DayOfTheWeek()
                    {
                        Name = "Lunes",
                        DayOfTheWeekId = new Guid()
                    };

                    martes = new DayOfTheWeek()
                    {
                        Name = "Martes",
                        DayOfTheWeekId = new Guid()
                    };

                    miercoles = new DayOfTheWeek()
                    {
                        Name = "Miercoles",
                        DayOfTheWeekId = new Guid()
                    };

                    jueves = new DayOfTheWeek()
                    {
                        Name = "Jueves",
                        DayOfTheWeekId = new Guid()
                    };

                    viernes = new DayOfTheWeek()
                    {
                        Name = "Viernes",
                        DayOfTheWeekId = new Guid()
                     };

                    sabado = new DayOfTheWeek()
                    {
                        Name = "Sabado",
                        DayOfTheWeekId = new Guid()
                    };

                    domingo = new DayOfTheWeek()
                    {
                        Name = "Lunes",
                        DayOfTheWeekId = new Guid()
                    };

                    context.Add(lunes);
                    context.Add(martes);
                    context.Add(miercoles);
                    context.Add(jueves);
                    context.Add(viernes);
                    context.Add(sabado);
                    context.Add(domingo);

                }

                var teachers = context.Teachers.ToList();

                Teacher teach1 = null;
                Teacher teach2 = null;
                Teacher teach3 = null;

                if (teachers.Count <= 0)
                {
                    teach1 = new Teacher()
                    {
                        TeacherId = new Guid(),
                        Name = "Mariano",
                        LastName = "Pagani",
                        DNI = "24.666.916",
                        isActive = true
                    };

                    teach2 = new Teacher()
                    {
                        TeacherId = new Guid(),
                        Name = "Sofia",
                        LastName = "Gomez",
                        DNI = "44.666.916",
                        isActive = true
                    };

                    teach3 = new Teacher()
                    {
                        TeacherId = new Guid(),
                        Name = "Karen",
                        LastName = "Aguirre",
                        DNI = "54.666.916",
                        isActive = true
                    };

                    context.Add(teach1);
                    context.Add(teach2);
                    context.Add(teach3);

                }

                var subjects = context.Subjects.ToList();
                Subject alg = null;
                Subject mat = null;
                Subject en = null;
                Subject prog = null;

                if (subjects.Count <= 0)
                {
                    alg = new Subject()
                    {
                        SubjectId = new Guid(),
                        Name = "Algoritmos",
                        DayOfTheWeekId = lunes.DayOfTheWeekId,
                        Hour = DateTime.Now,
                        TeacherId = teach1.TeacherId,
                        MaxStudents = 20
                    };

                    mat = new Subject()
                    {
                        SubjectId = new Guid(),
                        Name = "Matematica",
                        DayOfTheWeekId = miercoles.DayOfTheWeekId,
                        Hour = DateTime.Now,
                        TeacherId = teach2.TeacherId,
                        MaxStudents = 20
                    };

                    en = new Subject()
                    {
                        SubjectId = new Guid(),
                        Name = "Ingles",
                        DayOfTheWeekId = viernes.DayOfTheWeekId,
                        Hour = DateTime.Now,
                        TeacherId = teach3.TeacherId,
                        MaxStudents = 20
                    };

                    prog = new Subject()
                    {
                        SubjectId = new Guid(),
                        Name = "Fundamentos",
                        DayOfTheWeekId = viernes.DayOfTheWeekId,
                        Hour = DateTime.Now,
                        TeacherId = teach3.TeacherId,
                        MaxStudents = 20
                    };

                    context.Add(alg);
                    context.Add(mat);
                    context.Add(en);
                    context.Add(prog);

                }

                UserAcc user = null;
                UserAcc admin = null;

                var users = context.UserAccs.ToList();

                if (users.Count <= 0)
                {
                    user = new UserAcc()
                    {                        
                        Name = "Sonia",
                        LastName = "Troglio",
                        DNI = studentDNI,
                        Docket = studentDocket,
                        UserName = studentDNI
                    };

                    admin = new UserAcc()
                    {
                        Name = "Diego",
                        LastName = "Diaz",
                        DNI = adminDNI,
                        Docket = adminDocket,
                        UserName = adminDNI
                    };

                    var result = _usermgr.CreateAsync(admin, adminDocket).Result;
                    var userAdmin = _usermgr.FindByNameAsync(adminDNI).Result;
                    var userAdminRol = _usermgr.AddToRolesAsync(userAdmin, new string[] { rolAdmin }).Result;

                    var resultStudent = _usermgr.CreateAsync(user, studentDocket).Result;
                    var userStudent = _usermgr.FindByNameAsync(studentDNI).Result;
                    var userStudentRol = _usermgr.AddToRolesAsync(userStudent, new string[] { rolStudent }).Result;

                }            
                                

                context.SaveChanges();
            }
        }
    }
}
