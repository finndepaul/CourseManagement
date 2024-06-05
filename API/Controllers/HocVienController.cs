using AutoMapper;
using CourseManagement.Application.DataTransferObjects.HocVien.Request;
using CourseManagement.Application.Interfaces.Repositories;
using CourseManagement.Application.ValueObjects.Pagination;
using CourseManagement.Domain.Entities;
using CourseManagement.Domain.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HocVienController : ControllerBase
    {
        private readonly IHocVienRepos _repos;
        private readonly IMapper _mapper;

        public HocVienController(IHocVienRepos repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? keyword, [FromQuery] PaginationRequest request)
        {
            return Ok(await _repos.GetAll(keyword, request));
        }
        [HttpPost]
        public async Task<IActionResult> CreateNew(HocVienCreateRequest request, CancellationToken cancellation)
        {
            try
            {
                var result = await _repos.CreateHocVien(_mapper.Map<HocVien>(request), cancellation);
                if (result == ErrorMessage.ValueIsUnique)
                {
                    return BadRequest("Email và SDT đã có, vui lòng thêm lại");
                }
                else if (result == ErrorMessage.ModelIsNull)
                {
                    return BadRequest("Trường dữ liệu trống!!");
                }
                else
                {
                    return Ok("Thêm thành công");
                }
            }
            catch (Exception)
            {
                return BadRequest("Thêm thất bại!");
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRecord(HocVienUpdateRequest request, CancellationToken cancellation)
        {
            try
            {
                var result = await _repos.UpdateHocVien(_mapper.Map<HocVien>(request), cancellation);
                if (result == ErrorMessage.ValueIsUnique)
                {
                    return BadRequest("Email và SDT đã có, vui lòng cập nhật lại");
                }
                else if (result == ErrorMessage.ModelIsNull)
                {
                    return BadRequest("Trường dữ liệu trống!!");
                }
                else
                {
                    return Ok("Cập nhật thành công");
                }
            }
            catch (Exception)
            {
                return BadRequest("Cập nhật thất bại!");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteRecord(HocVienDeleteRequest request, CancellationToken cancellation)
        {
            try
            {
                var result = await _repos.DeleteHocVien(_mapper.Map<HocVien>(request), cancellation);
                if (result == ErrorMessage.ValueIsUnique)
                {
                    return BadRequest("Email và SDT đã có, vui lòng thêm lại");
                }
                else if (result == ErrorMessage.ModelIsNull)
                {
                    return BadRequest("Trường dữ liệu trống!!");
                }
                else
                {
                    return Ok("Xóa thành công");
                }
            }
            catch (Exception)
            {
                return BadRequest("Xóa thất bại!");
            }
        }
    }
}
