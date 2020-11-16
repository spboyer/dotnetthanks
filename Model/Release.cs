using System.Collections.Generic;

namespace dotnetthanks
{

    public record Release(int Id, string Name, string Tag)
    {
        public List<ChildRepo> ChildRepos { get; init; } = new List<ChildRepo>();
        public List<Contributor> Contributors { get; init; } = new List<Contributor>();

        public int Contributions { get; set; } = 0;
    }

    public record Contributor(string Name, string Link, int Count)
    {
        public List<RepoItem> Repos { get; init; } = new List<RepoItem>();
    }

    public record RepoItem(string Name, int Count);

    public record ChildRepo(string Name, string Url)
    {
        public string Repository { get => this.Url?.Split("/")[4]; }

        public string Owner { get => this.Url?.Split("/")[3]; }

        public string Tag { get => Url?.Substring(Url.LastIndexOf($"/") + 1); }
    }
}