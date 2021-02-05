using Conference.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conference.Data
{
    public interface ISpeakerRepository
    {
        Speaker Add(Speaker speaker);
        bool Delete(Speaker speakerToDelete);
        IEnumerable<Speaker> GetAllSpeakers();
        Speaker GetSpeaker(int id);
        int Save();
        Speaker UpdateSpeaker(Speaker speaker);
    }

    public class SpeakerRepository : ISpeakerRepository
    {
        private readonly ConfContext context;

        public SpeakerRepository(ConfContext context)
        {
            this.context = context;
        }
        public IEnumerable<Speaker> GetAllSpeakers()
        {
            
            return context.Speakers.ToList();
        }
        public Speaker GetSpeaker(int id)
        {
            
            return context.Speakers.Find(id);
        }
        public Speaker UpdateSpeaker(Speaker speaker)
        {
            return context.Update(speaker).Entity;
        }

        public Speaker Add(Speaker speaker)
        {
            return context.Add(speaker).Entity;
        }

        public bool Delete(Speaker speakerToDelete)
        {
            var deletedSpeaker = context.Speakers.Remove(speakerToDelete).Entity;
            if (deletedSpeaker!=null)
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
