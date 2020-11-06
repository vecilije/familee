using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Familee.Domain.Dtos;

namespace Familee.ApiClient.Gateways
{
    public class FamilyMemberApiGateway : IFamilyMemberApiGateway
    {
        private readonly HttpClient _httpClient;

        public FamilyMemberApiGateway(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public Task<List<FamilyMemberDto>> SearchAsync(string criteria)
        {
            return _httpClient.GetFromJsonAsync<List<FamilyMemberDto>>($"/api/familymembers?searchText={criteria}");
        }

        public Task<FamilyMemberDto> GetSingleAsync(Guid id)
        {
            return _httpClient.GetFromJsonAsync<FamilyMemberDto>($"/api/familymembers/{id}");
        }

        public async Task<FamilyMemberDto> AddAsync(FamilyMemberDto familyMember)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync($"/api/familymembers", familyMember);
            responseMessage.EnsureSuccessStatusCode();

            var createdFamilyMember = JsonSerializer
                .Deserialize<FamilyMemberDto>(await responseMessage.Content.ReadAsStringAsync());

            return createdFamilyMember;
        }

        public async Task<FamilyMemberDto> UpdateAsync(FamilyMemberDto familyMember)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync($"/api/familymembers/{familyMember.Id}", familyMember);
            responseMessage.EnsureSuccessStatusCode();

            var createdFamilyMember = JsonSerializer
                .Deserialize<FamilyMemberDto>(await responseMessage.Content.ReadAsStringAsync());

            return createdFamilyMember;
        }

        public async Task DeleteAsync(FamilyMemberDto familyMember)
        {
            var responseMessage = await _httpClient.DeleteAsync($"/api/familymembers/{familyMember.Id}");
            responseMessage.EnsureSuccessStatusCode();
        }
    }
}