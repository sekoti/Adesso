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

        var groups = AssignTeamsToGroups(countryGroup, request);
        return new DrawResponseModel
        {
            DrawnBy = request.Surname,
            DrawDate = DateTime.Now,
            Groups = groups
        };
    }
    private List<GroupResponseModel> AssignTeamsToGroups(List<IGrouping<int, Team>> countryGroup, DrawRequestModel request)
    {
        var drawResult = new Draw
        {
            DrawnBy = request.Name + " "+ request.Surname,
            DrawDate = DateTime.Now
        };
        var groups = new List<GroupResponseModel>();
        var random = new Random();
        // Her grup için takımları dağıt
        for (int groupIndex = 0; groupIndex < request.GroupCount; groupIndex++)
        {
            var group = new GroupResponseModel { GroupName = ((char)('A' + groupIndex)).ToString() };

            var groupEnt = new Group
            {
                GroupCount = request.GroupCount,
                GroupName = group.GroupName,
                DrawId = drawResult.Id
            };

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
                                var teamEnt = new GroupTeam
                                {
                                    GroupId = groupEnt.Id,
                                    TeamId =team.Id
                                };
                                groupEnt.GroupTeams.Add(teamEnt);
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
                if (request.GroupCount == 4 && teamsForGroup.Count >= 8)
                {
                    break;
                }
                // Eğer grup 8 gruptan oluşuyorsa, her grup 4 takım almalı
                else if (request.GroupCount == 8 && teamsForGroup.Count >= 4)
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
            drawResult.Groups.Add(groupEnt);
        }

        _unitOfWork.Draws.AddAsync(drawResult);
        _unitOfWork.SaveAsync();
        return groups;
    }

}
