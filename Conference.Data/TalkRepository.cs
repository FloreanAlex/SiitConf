using Conference.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conference.Data
{
    public interface ITalkRepository
    {
        Talk Add(Talk talk);
        bool Delete(Talk talkToDelete);
        IEnumerable<Talk> GetAllTalks();
        Talk GetTalk(int id);
        int Save();
        Talk UpdateTalk(Talk talk);
    }

    public class TalkRepository : ITalkRepository
    {
        private readonly ConfContext context;

        public TalkRepository(ConfContext context)
        {
            this.context = context;
        }
        public IEnumerable<Talk> GetAllTalks()
        {
            return context.Talks.ToList();
        }

        public Talk GetTalk (int id)
        {
            return context.Talks.Find(id);
        }

        public Talk UpdateTalk(Talk talk)
        {
            return context.Update(talk).Entity;
        }

        public Talk Add (Talk talk)
        {
            return context.Add(talk).Entity;
        }

        public bool Delete(Talk talkToDelete)
        {
            var existingTalk = context.Talks.Remove(talkToDelete).Entity;
            if (existingTalk != null)
            {
                return true;
            }
            return false;
        }

        public int Save()
        {
            return context.SaveChanges();
        }


    }
}
