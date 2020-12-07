using System;
using System.Collections.Generic;
using System.Text.Json;

namespace dotnetthanks
{

    public class Repos : IRepos
    {
        public Repos()
        {
            _items = new List<Repo>();
            _items.Add(new Core());
        }

        private  List<Repo> _items;
        List<Repo> IRepos.Items => _items;

    }

    public interface IRepos
    {
        List<Repo> Items{get;}
    }

    public class AspNetCore : Repo
    {
        public AspNetCore() : base("./Data/aspnetcore.json", "aspnetcore")
        {

        }

    }

    public class Core : Repo
    {
        public Core() : base("./Data/core.json", "core")
        {

        }

    }

    public class Runtime : Repo
    {
        public Runtime() : base("./Data/runtime.json","runtime")
        {

        }

    }

    public class Sdk : Repo
    {
        public Sdk() : base("./Data/sdk.json", "sdk")
        {

        }

    }

    public interface IRepo
    {
        int TotalContributorCount();
        int TotalContributionCount();

        List<Release> Releases { get; set; }

        Release ReleaseByTag(string tag);

        int ContributionCount(string tag);

        int ContributorCount(string tag);

        List<Contributor> Contributors(string tag);

        void Init(string dataFile);
    
    }

    public class Repo : IRepo
    {
        public string Name { get; set; }
        public Repo(string dataFile, string name)
        {
            Init(dataFile);
            Name = name;
        }
        public List<Release> Releases { get; set; }

        public int ContributionCount(string tag)
        {
            var release = Releases.Find(r => r.Tag == tag);
            if (release != null)
                return release.Contributions;

            return 0;
        }

        public int ContributorCount(string tag)
        {
            var release = Releases.Find(r => r.Tag == tag);
            if (release != null)
                return release.Contributors.Count;

            return 0;
        }

        public List<Contributor> Contributors(string tag)
        {
            var release = Releases.Find(r => r.Tag == tag);
            if (release != null)
                return release.Contributors;

            return null;
        }

        public void Init(string dataFile)
        {
            var data = System.IO.File.ReadAllText(dataFile);
            Releases = JsonSerializer.Deserialize<List<Release>>(data);

            // filter the releases that have 0 contributions.
            Releases.RemoveAll(r => r.Contributions == 0);

            // Clean up bot contributors
            foreach (var rel in Releases)
            {
                rel.Contributors.FindAll(c => c.Name.StartsWith("dotnet-maestro", StringComparison.OrdinalIgnoreCase)).ForEach(p => rel.Contributions -= p.Count);
                rel.Contributors.RemoveAll(c => c.Name.StartsWith("dotnet-maestro", StringComparison.OrdinalIgnoreCase));
            }

            
        }

        public Release ReleaseByTag(string tag)
        {
            var release = Releases.Find(r => r.Tag == tag);
            if (release != null)
                return release;

            return null;
        }

        public int TotalContributionCount()
        {
            int count = 0;
            Releases.ForEach(r => count += r.Contributions);
            return count;

        }

        public int TotalContributorCount()
        {
            int count = 0;
            Releases.ForEach(r => count += r.Contributors.Count);
            return count;
        }
    }

}