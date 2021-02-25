using notes.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace notes.Core
{
    public interface INoteServices
    {
        Note CreateNote(Note note);
        Note GetNote(int id);
        List<Note> GetNotes();
        void DeleteNote(int id);
        void EditNote(Note note);
    }
}
