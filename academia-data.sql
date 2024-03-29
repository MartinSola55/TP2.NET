USE [academia]
GO
SET IDENTITY_INSERT [dbo].[cargos] ON 

INSERT [dbo].[cargos] ([id_cargo], [desc_cargo]) VALUES (1, N'Jefe de cátedra')
INSERT [dbo].[cargos] ([id_cargo], [desc_cargo]) VALUES (2, N'Titular')
INSERT [dbo].[cargos] ([id_cargo], [desc_cargo]) VALUES (3, N'Auxiliar')
INSERT [dbo].[cargos] ([id_cargo], [desc_cargo]) VALUES (4, N'Reemplazante')
INSERT [dbo].[cargos] ([id_cargo], [desc_cargo]) VALUES (5, N'Tutor')
SET IDENTITY_INSERT [dbo].[cargos] OFF
GO
SET IDENTITY_INSERT [dbo].[especialidades] ON 

INSERT [dbo].[especialidades] ([id_especialidad], [desc_especialidad]) VALUES (1, N'ISI')
INSERT [dbo].[especialidades] ([id_especialidad], [desc_especialidad]) VALUES (2, N'IM')
INSERT [dbo].[especialidades] ([id_especialidad], [desc_especialidad]) VALUES (3, N'IE')
INSERT [dbo].[especialidades] ([id_especialidad], [desc_especialidad]) VALUES (4, N'IQ')
INSERT [dbo].[especialidades] ([id_especialidad], [desc_especialidad]) VALUES (5, N'IC')
INSERT [dbo].[especialidades] ([id_especialidad], [desc_especialidad]) VALUES (14, N'IEM')
SET IDENTITY_INSERT [dbo].[especialidades] OFF
GO
SET IDENTITY_INSERT [dbo].[planes] ON 

INSERT [dbo].[planes] ([id_plan], [desc_plan], [id_especialidad]) VALUES (1, N'Plan 2008', 3)
INSERT [dbo].[planes] ([id_plan], [desc_plan], [id_especialidad]) VALUES (2, N'Plan 2008', 4)
INSERT [dbo].[planes] ([id_plan], [desc_plan], [id_especialidad]) VALUES (3, N'Plan 2023', 1)
INSERT [dbo].[planes] ([id_plan], [desc_plan], [id_especialidad]) VALUES (8, N'Plan 2008', 5)
INSERT [dbo].[planes] ([id_plan], [desc_plan], [id_especialidad]) VALUES (11, N'Plan 2008', 1)
INSERT [dbo].[planes] ([id_plan], [desc_plan], [id_especialidad]) VALUES (12, N'Plan 2008', 2)
INSERT [dbo].[planes] ([id_plan], [desc_plan], [id_especialidad]) VALUES (14, N'Plan 1998', 3)
SET IDENTITY_INSERT [dbo].[planes] OFF
GO
SET IDENTITY_INSERT [dbo].[comisiones] ON 

INSERT [dbo].[comisiones] ([id_comision], [desc_comision], [anio_especialidad], [id_plan]) VALUES (1, N'305', 2008, 8)
INSERT [dbo].[comisiones] ([id_comision], [desc_comision], [anio_especialidad], [id_plan]) VALUES (2, N'301', 2023, 3)
INSERT [dbo].[comisiones] ([id_comision], [desc_comision], [anio_especialidad], [id_plan]) VALUES (4, N'501', 2008, 1)
INSERT [dbo].[comisiones] ([id_comision], [desc_comision], [anio_especialidad], [id_plan]) VALUES (5, N'403', 2008, 8)
INSERT [dbo].[comisiones] ([id_comision], [desc_comision], [anio_especialidad], [id_plan]) VALUES (6, N'302', 2023, 3)
INSERT [dbo].[comisiones] ([id_comision], [desc_comision], [anio_especialidad], [id_plan]) VALUES (7, N'301', 2008, 1)
INSERT [dbo].[comisiones] ([id_comision], [desc_comision], [anio_especialidad], [id_plan]) VALUES (8, N'303', 2023, 3)
INSERT [dbo].[comisiones] ([id_comision], [desc_comision], [anio_especialidad], [id_plan]) VALUES (9, N'303', 2008, 1)
SET IDENTITY_INSERT [dbo].[comisiones] OFF
GO
SET IDENTITY_INSERT [dbo].[materias] ON 

INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan]) VALUES (2, N'.NET', 4, 200, 3)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan]) VALUES (3, N'Java', 4, 200, 3)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan]) VALUES (4, N'Diseño de Sistemas', 6, 150, 3)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan]) VALUES (5, N'Gestión de Datos', 5, 95, 8)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan]) VALUES (6, N'Sintaxis', 8, 150, 2)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan]) VALUES (8, N'Analisis Numerico', 3, 100, 3)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan]) VALUES (9, N'Paradigmas de Programación', 8, 150, 3)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan]) VALUES (10, N'Algebra y Geometría analítica', 4, 200, 1)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan]) VALUES (11, N'Algebra y Geometría analítica', 4, 200, 3)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan]) VALUES (12, N'Algebra y Geometría analítica', 4, 200, 2)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan]) VALUES (13, N'Algebra y Geometría analítica', 4, 200, 8)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan]) VALUES (14, N'Análisis Matemático II', 4, 128, 3)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan]) VALUES (15, N'Análisis Matemático I', 4, 128, 3)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan]) VALUES (18, N'Física I', 6, 162, 1)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan]) VALUES (19, N'Física III', 6, 123, 8)
INSERT [dbo].[materias] ([id_materia], [desc_materia], [hs_semanales], [hs_totales], [id_plan]) VALUES (20, N'Física I', 6, 162, 12)
SET IDENTITY_INSERT [dbo].[materias] OFF
GO
SET IDENTITY_INSERT [dbo].[cursos] ON 

INSERT [dbo].[cursos] ([id_curso], [id_materia], [id_comision], [anio_calendario], [cupo]) VALUES (3, 3, 2, 2022, 50)
INSERT [dbo].[cursos] ([id_curso], [id_materia], [id_comision], [anio_calendario], [cupo]) VALUES (5, 4, 2, 2022, 45)
INSERT [dbo].[cursos] ([id_curso], [id_materia], [id_comision], [anio_calendario], [cupo]) VALUES (12, 6, 4, 2008, 120)
INSERT [dbo].[cursos] ([id_curso], [id_materia], [id_comision], [anio_calendario], [cupo]) VALUES (13, 2, 2, 2020, 38)
INSERT [dbo].[cursos] ([id_curso], [id_materia], [id_comision], [anio_calendario], [cupo]) VALUES (14, 2, 6, 2020, 42)
INSERT [dbo].[cursos] ([id_curso], [id_materia], [id_comision], [anio_calendario], [cupo]) VALUES (15, 2, 8, 2020, 42)
INSERT [dbo].[cursos] ([id_curso], [id_materia], [id_comision], [anio_calendario], [cupo]) VALUES (17, 8, 8, 2007, 33)
INSERT [dbo].[cursos] ([id_curso], [id_materia], [id_comision], [anio_calendario], [cupo]) VALUES (18, 2, 2, 2022, 40)
INSERT [dbo].[cursos] ([id_curso], [id_materia], [id_comision], [anio_calendario], [cupo]) VALUES (19, 3, 7, 2005, 300)
SET IDENTITY_INSERT [dbo].[cursos] OFF
GO
SET IDENTITY_INSERT [dbo].[personas] ON 

INSERT [dbo].[personas] ([id_persona], [nombre], [apellido], [direccion], [email], [telefono], [fecha_nac], [legajo], [tipo_persona], [id_plan]) VALUES (2, N'Pulga', N'Rodriguez', N'Santa Fe 1050', N'elpulga10@gmail.com', N'342120450', CAST(N'1984-08-17T00:00:00.000' AS DateTime), 24186, 1, 1)
INSERT [dbo].[personas] ([id_persona], [nombre], [apellido], [direccion], [email], [telefono], [fecha_nac], [legajo], [tipo_persona], [id_plan]) VALUES (3, N'Tomas', N'Alvarez', N'9 de Julio 1174', N'hola@gmail.com', N'3478505050', CAST(N'2022-09-24T00:00:00.000' AS DateTime), 47920, 2, 3)
INSERT [dbo].[personas] ([id_persona], [nombre], [apellido], [direccion], [email], [telefono], [fecha_nac], [legajo], [tipo_persona], [id_plan]) VALUES (4, N'Martín', N'Sola', N'Mendoza 379', N'martinsola11@gmail.com', N'3404437748', CAST(N'2000-08-01T00:00:00.000' AS DateTime), 48618, 2, 11)
INSERT [dbo].[personas] ([id_persona], [nombre], [apellido], [direccion], [email], [telefono], [fecha_nac], [legajo], [tipo_persona], [id_plan]) VALUES (7, N'Juan', N'Gomez', N'9 de julio 1122', N'hola@gmail.com', N'131155455', CAST(N'2022-08-11T00:00:00.000' AS DateTime), 20486, 1, 3)
INSERT [dbo].[personas] ([id_persona], [nombre], [apellido], [direccion], [email], [telefono], [fecha_nac], [legajo], [tipo_persona], [id_plan]) VALUES (10, N'Admin', N'Admin', N'Admin 123', N'admin@admin.com', N'123', CAST(N'2000-01-01T00:00:00.000' AS DateTime), 0, 3, 1)
INSERT [dbo].[personas] ([id_persona], [nombre], [apellido], [direccion], [email], [telefono], [fecha_nac], [legajo], [tipo_persona], [id_plan]) VALUES (11, N'Alex', N'Paiano', N'Funes 765', N'alex14@gmail.com', N'342756489', CAST(N'2000-09-05T00:00:00.000' AS DateTime), 48157, 2, 11)
INSERT [dbo].[personas] ([id_persona], [nombre], [apellido], [direccion], [email], [telefono], [fecha_nac], [legajo], [tipo_persona], [id_plan]) VALUES (12, N'Federico', N'Leiva', N'1 de Mayo 574', N'fedeleiva@gmail.com', N'3404698451', CAST(N'2001-01-12T00:00:00.000' AS DateTime), 49517, 2, 8)
INSERT [dbo].[personas] ([id_persona], [nombre], [apellido], [direccion], [email], [telefono], [fecha_nac], [legajo], [tipo_persona], [id_plan]) VALUES (13, N'Franco', N'Pinciroli', N'San Martin 634', N'francop@gmail.com', N'342487641', CAST(N'2001-03-08T00:00:00.000' AS DateTime), 47854, 2, 11)
INSERT [dbo].[personas] ([id_persona], [nombre], [apellido], [direccion], [email], [telefono], [fecha_nac], [legajo], [tipo_persona], [id_plan]) VALUES (15, N'Bichi', N'Fuertes', N'Santa Fe 568', N'soyelbichi10@gmail.com', N'342458794', CAST(N'1970-11-05T00:00:00.000' AS DateTime), 12410, 1, 1)
INSERT [dbo].[personas] ([id_persona], [nombre], [apellido], [direccion], [email], [telefono], [fecha_nac], [legajo], [tipo_persona], [id_plan]) VALUES (23, N'Pedro', N'Moran', N'8 de febrero 111', N'pedro@gmail.com', N'123123132', CAST(N'2005-08-31T00:00:00.000' AS DateTime), 11333, 2, 3)
INSERT [dbo].[personas] ([id_persona], [nombre], [apellido], [direccion], [email], [telefono], [fecha_nac], [legajo], [tipo_persona], [id_plan]) VALUES (24, N'Rodrigo', N'De Paul', N'Atletico Madrid', N'Rodri@gmail.com', N'777000777', CAST(N'1995-09-15T00:00:00.000' AS DateTime), 47952, 2, 3)
INSERT [dbo].[personas] ([id_persona], [nombre], [apellido], [direccion], [email], [telefono], [fecha_nac], [legajo], [tipo_persona], [id_plan]) VALUES (27, N'Norberto ', N'Matthaus', N'Francia 1566', N'Norber@gmail.com', N'1111111111', CAST(N'1922-10-31T18:25:43.000' AS DateTime), 111, 1, 3)
INSERT [dbo].[personas] ([id_persona], [nombre], [apellido], [direccion], [email], [telefono], [fecha_nac], [legajo], [tipo_persona], [id_plan]) VALUES (28, N'Matias', N'Fagnano', N'Calle falsa 123', N'colo@fag.com', N'2478545454', CAST(N'2000-08-29T18:50:10.000' AS DateTime), 47925, 2, 11)
INSERT [dbo].[personas] ([id_persona], [nombre], [apellido], [direccion], [email], [telefono], [fecha_nac], [legajo], [tipo_persona], [id_plan]) VALUES (29, N'Juan', N'Martinez', N'Hugarte 89', N'juan@lolo.com', N'2445545658', CAST(N'2000-09-29T18:53:29.000' AS DateTime), 33333, 2, 8)
SET IDENTITY_INSERT [dbo].[personas] OFF
GO
SET IDENTITY_INSERT [dbo].[docentes_cursos] ON 

INSERT [dbo].[docentes_cursos] ([id_dictado], [id_curso], [id_docente], [id_cargo]) VALUES (4, 5, 2, 1)
INSERT [dbo].[docentes_cursos] ([id_dictado], [id_curso], [id_docente], [id_cargo]) VALUES (5, 3, 2, 2)
INSERT [dbo].[docentes_cursos] ([id_dictado], [id_curso], [id_docente], [id_cargo]) VALUES (6, 13, 7, 1)
INSERT [dbo].[docentes_cursos] ([id_dictado], [id_curso], [id_docente], [id_cargo]) VALUES (7, 5, 7, 1)
INSERT [dbo].[docentes_cursos] ([id_dictado], [id_curso], [id_docente], [id_cargo]) VALUES (12, 12, 2, 4)
INSERT [dbo].[docentes_cursos] ([id_dictado], [id_curso], [id_docente], [id_cargo]) VALUES (14, 13, 15, 1)
INSERT [dbo].[docentes_cursos] ([id_dictado], [id_curso], [id_docente], [id_cargo]) VALUES (17, 12, 7, 3)
INSERT [dbo].[docentes_cursos] ([id_dictado], [id_curso], [id_docente], [id_cargo]) VALUES (18, 17, 15, 2)
SET IDENTITY_INSERT [dbo].[docentes_cursos] OFF
GO
SET IDENTITY_INSERT [dbo].[condiciones_alumnos] ON 

INSERT [dbo].[condiciones_alumnos] ([id_condicion], [desc_condicion]) VALUES (1, N'Promoción')
INSERT [dbo].[condiciones_alumnos] ([id_condicion], [desc_condicion]) VALUES (2, N'Regular')
INSERT [dbo].[condiciones_alumnos] ([id_condicion], [desc_condicion]) VALUES (3, N'Libre')
INSERT [dbo].[condiciones_alumnos] ([id_condicion], [desc_condicion]) VALUES (4, N'Inscripto')
SET IDENTITY_INSERT [dbo].[condiciones_alumnos] OFF
GO
SET IDENTITY_INSERT [dbo].[alumnos_inscripciones] ON 

INSERT [dbo].[alumnos_inscripciones] ([id_inscripcion], [id_alumno], [id_curso], [id_condicion], [nota]) VALUES (1, 4, 3, 1, 8)
INSERT [dbo].[alumnos_inscripciones] ([id_inscripcion], [id_alumno], [id_curso], [id_condicion], [nota]) VALUES (8, 4, 12, 1, 6)
INSERT [dbo].[alumnos_inscripciones] ([id_inscripcion], [id_alumno], [id_curso], [id_condicion], [nota]) VALUES (9, 4, 13, 1, 9)
INSERT [dbo].[alumnos_inscripciones] ([id_inscripcion], [id_alumno], [id_curso], [id_condicion], [nota]) VALUES (12, 3, 3, 1, 10)
INSERT [dbo].[alumnos_inscripciones] ([id_inscripcion], [id_alumno], [id_curso], [id_condicion], [nota]) VALUES (14, 12, 15, 2, NULL)
INSERT [dbo].[alumnos_inscripciones] ([id_inscripcion], [id_alumno], [id_curso], [id_condicion], [nota]) VALUES (16, 13, 3, 4, NULL)
INSERT [dbo].[alumnos_inscripciones] ([id_inscripcion], [id_alumno], [id_curso], [id_condicion], [nota]) VALUES (19, 13, 5, 1, 10)
INSERT [dbo].[alumnos_inscripciones] ([id_inscripcion], [id_alumno], [id_curso], [id_condicion], [nota]) VALUES (24, 4, 5, 2, NULL)
INSERT [dbo].[alumnos_inscripciones] ([id_inscripcion], [id_alumno], [id_curso], [id_condicion], [nota]) VALUES (49, 4, 17, 1, 10)
INSERT [dbo].[alumnos_inscripciones] ([id_inscripcion], [id_alumno], [id_curso], [id_condicion], [nota]) VALUES (54, 3, 18, 1, 6)
INSERT [dbo].[alumnos_inscripciones] ([id_inscripcion], [id_alumno], [id_curso], [id_condicion], [nota]) VALUES (55, 3, 12, 4, NULL)
SET IDENTITY_INSERT [dbo].[alumnos_inscripciones] OFF
GO
SET IDENTITY_INSERT [dbo].[usuarios] ON 

INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [cambia_clave], [id_persona]) VALUES (3, N'martin', N'123', 1, 0, 4)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [cambia_clave], [id_persona]) VALUES (4, N'tomas', N'123', 1, 1, 3)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [cambia_clave], [id_persona]) VALUES (6, N'admin', N'admin', 1, NULL, 10)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [cambia_clave], [id_persona]) VALUES (10, N'alexpaiano', N'alexpaiano', 1, NULL, 11)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [cambia_clave], [id_persona]) VALUES (11, N'pulga', N'123', 1, 0, 2)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [cambia_clave], [id_persona]) VALUES (17, N'fedel', N'123', 0, NULL, 12)
INSERT [dbo].[usuarios] ([id_usuario], [nombre_usuario], [clave], [habilitado], [cambia_clave], [id_persona]) VALUES (34, N'soyelbichi10', N'bichi', 1, NULL, 15)
SET IDENTITY_INSERT [dbo].[usuarios] OFF
GO
