using FirmaTakip.Entities;
using FirmaTakip.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirmaTakip.Repositories
{
    public class NoteRepository:GenericRepository<Note>,INoteRepository
    {
    }
}
