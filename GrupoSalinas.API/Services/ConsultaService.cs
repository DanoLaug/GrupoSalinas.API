using GrupoSalinas.API.Data;
using GrupoSalinas.API.DTOs;
using GrupoSalinas.API.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GrupoSalinas.API.Services.Implementaciones
{
    public class ConsultaService : IConsultaService
    {
        private readonly ApplicationDbContext _context;

        public ConsultaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ConsultaCursoConAlumnosDTO>> ObtenerAlumnosPorCurso(int cursoId)
        {
            var result = new List<ConsultaCursoConAlumnosDTO>();

            using (var connection = _context.Database.GetDbConnection())
            {
                await connection.OpenAsync();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "sp_AlumnosPorCurso";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    var param = command.CreateParameter();
                    param.ParameterName = "@CursoId";
                    param.Value = cursoId;
                    command.Parameters.Add(param);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        ConsultaCursoConAlumnosDTO dto = null;

                        while (await reader.ReadAsync())
                        {
                            if (dto == null)
                            {
                                dto = new ConsultaCursoConAlumnosDTO
                                {
                                    Curso = reader["Curso"].ToString(),
                                    Profesor = reader["Profesor"].ToString(),
                                    Alumnos = new List<string>()
                                };
                            }

                            dto.Alumnos.Add(reader["Alumno"].ToString());
                        }

                        if (dto != null)
                            result.Add(dto);
                    }
                }
            }

            return result;
        }

        public async Task<List<ConsultaCursosPorProfesorDTO>> ObtenerCursosPorProfesor(int profesorId)
        {
            var resultados = new List<ConsultaCursosPorProfesorDTO>();

            using (var connection = _context.Database.GetDbConnection())
            {
                await connection.OpenAsync();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "sp_CursosPorProfesor";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    var param = command.CreateParameter();
                    param.ParameterName = "@ProfesorId";
                    param.Value = profesorId;
                    command.Parameters.Add(param);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var curso = reader["Curso"].ToString();
                            var alumno = reader["Alumno"].ToString();

                            var existing = resultados.FirstOrDefault(r => r.Curso == curso);
                            if (existing != null)
                            {
                                existing.Alumnos.Add(alumno);
                            }
                            else
                            {
                                resultados.Add(new ConsultaCursosPorProfesorDTO
                                {
                                    Curso = curso,
                                    Alumnos = new List<string> { alumno }
                                });
                            }
                        }
                    }
                }
            }

            return resultados;
        }
    }
}
