using Microsoft.EntityFrameworkCore;
using MySchool.DAL.Entities;
using System;

namespace MySchool.DAL.Repository
{
    public class UnitOfWork : IDisposable
    {

        private MySchoolDb db = new MySchoolDb(new DbContextOptions<MySchoolDb>());

        private GenericRepository<Class> classRepository;
        private GenericRepository<Teacher> teacherRepository;
        private GenericRepository<Student> studentRepository;
        private GenericRepository<Grade> gradeRepository;
        private GenericRepository<Subject> subjectRepository;
        private GenericRepository<GradeClass> gradeClassesRepository;
        private GenericRepository<SubjectGrade> subjectGradeRepository;

        public GenericRepository<Class> ClassRepository
        {
            get
            {
                if (this.classRepository == null)
                {
                    this.classRepository = new GenericRepository<Class>(db);
                }
                return classRepository;
            }
        }

        public GenericRepository<Teacher> TeacherRepository
        {
            get
            {
                if (this.teacherRepository == null)
                {
                    this.teacherRepository = new GenericRepository<Teacher>(db);
                }
                return teacherRepository;
            }
        }
        public GenericRepository<Student> StudentRepository
        {
            get
            {
                if (this.studentRepository == null)
                {
                    this.studentRepository = new GenericRepository<Student>(db);
                }
                return studentRepository;
            }
        }
        public GenericRepository<Grade> GradeRepository
        {
            get
            {
                if (this.gradeRepository == null)
                {
                    this.gradeRepository = new GenericRepository<Grade>(db);
                }
                return gradeRepository;
            }
        }

        public GenericRepository<Subject> SubjectRepository
        {
            get
            {
                if (this.subjectRepository == null)
                {
                    this.subjectRepository = new GenericRepository<Subject>(db);
                }
                return subjectRepository;
            }
        }

        public GenericRepository<GradeClass> GradeClassesRepository
        {
            get
            {
                if (this.gradeClassesRepository == null)
                {
                    this.gradeClassesRepository = new GenericRepository<GradeClass>(db);
                }
                return gradeClassesRepository;
            }
        }

        public GenericRepository<SubjectGrade> SubjectGradeRepository
        {
            get
            {
                if (this.subjectGradeRepository == null)
                {
                    this.subjectGradeRepository = new GenericRepository<SubjectGrade>(db);
                }
                return subjectGradeRepository;
            }
        }


        public void Save()
        {
            db.SaveChanges();
        }



        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
