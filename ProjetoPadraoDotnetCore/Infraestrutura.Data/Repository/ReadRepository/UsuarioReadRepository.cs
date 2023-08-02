﻿using System;
using System.Linq;
using Infraestrutura.DataBaseContext;
using Infraestrutura.Entity;
using Infraestrutura.Repository.Interface.Usuario;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repository.ReadRepository
{
    public class UsuarioReadRepository : BaseReadRepository<Usuario>, IUsuarioReadRepository
    {
        private Context _context;

        public UsuarioReadRepository(Context context) : base(context)
        {
            _context = context;
        }

        public Usuario GetByIdWithInclude(int id)
        {
            return _context.Usuario.FirstOrDefault(x => x.IdUsuario == id) ??
                   throw new InvalidOperationException($"Usuário com Id {id} não encontrado!");
        }

    }
}