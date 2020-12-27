using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyChallange.Models
{
    public class AlertMessages
    {
        public const string
            RolError = "Error, para entrar en esta pagina debe loguear con el Rol de ",
            Success = "Se ha completado la tarea exitosamente.",
            Error = "La acción no se ha completado.",
            NeedTeacher = "Debe tener al menos un Profesor creado antes de crear una materia.",            
            SubjectError = "No se ha podido completar la inscripción.",
            SubjectSuccess = "Se ha inscripto en la materia exitosamente.",
            TeacherActive = "No tiene ningun profesor en estado Activo, primero debe activar uno.",
            TeacherDelete = "Se ha eliminado el profesor exitosamente",
            TeacherState = "Se ha cambiado el estado exitosamente";
    }
}
