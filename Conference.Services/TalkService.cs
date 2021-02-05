using Conference.Data;
using Conference.Domain;
using System;
using System.Collections.Generic;
using System.Text;


namespace Conference.Services
{
    public interface ITalkService
    {
        Talk Add(Talk talk);
        bool Delete(Talk talk);
        IEnumerable<Talk> GetAllTalks();
        Talk GetTalkById(int id);
        int Save();
        Talk Update(Talk talk);
    }

    public class TalkService : ITalkService
    {
        private readonly ITalkRepository repo;

        public TalkService(ITalkRepository repo)
        {
            this.repo = repo;
        }

        public IEnumerable<Talk> GetAllTalks()
        {
            return repo.GetAllTalks();
        }
        public Talk GetTalkById(int id)
        {
            return repo.GetTalk(id);
        }
        public Talk Update(Talk talk)
        {
            return repo.UpdateTalk(talk);
        }

        public Talk Add (Talk talk)
        {
            return repo.Add(talk);
        }

        public bool Delete(Talk talk)
        {
            return repo.Delete(talk);
        }
        public int Save()
        {
            return repo.Save();
        }
    }
}
