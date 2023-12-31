﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPTAT.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IYearGroupRepository YearGroupRepository { get; }
        IProgrammeRepository ProgrammeRepository { get; }
        IFacultyRepository FacultyRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        ICourseRepository CourseRepository { get; }
        IAdmittedClassRepository AdmittedClassRepository { get; }
        IAcademicYearRepository AcademicYearRepository { get; }
        IStudentRepository StudentRepository { get; }
        IDebtorRepository DebtorRepository { get; }
        IOtpRepository OtpRepository { get; }
        IAttendanceRepository AttendanceRepository { get; }
        Task<bool> Save();
    }
}
