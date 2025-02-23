using AdessoDraw.Application.Interfaces;
using AdessoDraw.Application.Models.RequestModels;
using AdessoDraw.Application.Models.ResponseModels;
using AdessoDraw.Domain.Entities;
using AdessoDraw.Domain.UOW;

namespace AdessoDraw.Application.Services;
public class DrawService : IDrawService
{
    private readonly IUnitOfWork _unitOfWork;

    // Constructor injection ile IUnitOfWork'i alıyoruz.
    public DrawService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DrawResponseModel> DrawGroupsAsync(DrawRequestModel request)
    {
        var teams = await _unitOfWork.Teams.GetAllAsync();
        var random = new Random();
        var countryGroup = teams.GroupBy(i => i.CountryId).OrderBy(x => random.Next()).ToList();

        var groups = AssignTeamsToGroups(countryGroup, request.GroupCount);
        return new DrawResponseModel
        {
            DrawnBy = request.Surname,
            DrawDate = DateTime.Now,
            Groups = groups
        };
    }
    private List<GroupResponseModel> AssignTeamsToGroups(List<IGrouping<int, Team>> countryGroup, int groupCount)
    {
        var groups = new List<GroupResponseModel>();
        var random = new Random();
        // Her grup için takımları dağıt
        for (int groupIndex = 0; groupIndex < groupCount; groupIndex++)
        {
            var group = new GroupResponseModel { GroupName = ((char)('A' + groupIndex)).ToString() };

            var teamsForGroup = new List<TeamResponseModel>();

            // Ülkelerden birer takım seç
            foreach (var countryGroupEntry in countryGroup.OrderBy(x => random.Next()))
            {
                if (countryGroupEntry.Any())
                {
                    var result = false;
                    do
                    {
                        var team = countryGroupEntry.Where(t=> !groups.Any(i=>i.Teams.Any(i=>i.Name==t.Name)))
                            .OrderBy(x => random.Next())
                            .FirstOrDefault();
                        if (team != null)
                        {
                            if (!groups.Any(i => i.Teams.Any(i => i.Name == team.Name)))
                            {
                                teamsForGroup.Add(new TeamResponseModel { Name = team.Name });
                                countryGroupEntry.ToList().Remove(team);

                                result = true;
                            }
                        }
                        else
                        {
                            break;
                        }
                       
                    } while (!result);

                }

                // Eğer grup 4 gruptan oluşuyorsa, her grup 8 takım almalı
                if (groupCount == 4 && teamsForGroup.Count >= 8)
                {
                    break;
                }
                // Eğer grup 8 gruptan oluşuyorsa, her grup 4 takım almalı
                else if (groupCount == 8 && teamsForGroup.Count >= 4)
                {
                    break;
                }
            }

            // Grup içindeki takımları ekle
            foreach (var team in teamsForGroup)
            {
                group.Teams.Add(new TeamResponseModel { Name = team.Name });
            }

            groups.Add(group);
        }

        return groups;
    }

}
