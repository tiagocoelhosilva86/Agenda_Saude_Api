﻿using AgendaSaude.Api.Domain.Entities;
using AgendaSaude.Api.Domain.Interfaces;
using AgendaSaude.Api.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AgendaSaude.Api.Infra.Data.Repositories
{
    public class AgendaRepository : IAgendaRepository
    {
        public readonly ApplicationDbContext _context;

        public AgendaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Agenda> AdicionarAgenda(Agenda agenda)
        {
            _context.Agenda.Add(agenda);
            await _context.SaveChangesAsync();

            return agenda;
        }

        public async Task<List<Agenda>> ListarAgendas()
        {
            return await _context.Agenda.Include(x => x.Paciente).ToListAsync();
        }

        public async Task<List<Agenda>> ListarAgendasporIdProficional(Guid id)
        {
            return await _context.Agenda.Include(x=> x.Paciente).Where(x => x.IdProficional == id).OrderBy(x => x.DataInicio).ToListAsync();
        }
    }
}
