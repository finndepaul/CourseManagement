using AutoMapper;
using CourseManagement.Application.DataTransferObjects.LoaiKhoaHoc;
using CourseManagement.Application.DataTransferObjects.LoaiKhoaHoc.Request;
using CourseManagement.Application.Interfaces.Repositories;
using CourseManagement.Domain.Entities;
using CourseManagement.Domain.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiKhoaHocController : ControllerBase
    {
        private readonly ILoaiKhoaHocRepos _repos;
        private readonly IMapper _mapper;
        public LoaiKhoaHocController(ILoaiKhoaHocRepos repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNew(LoaiKhoaHocCreateRequest request, CancellationToken cancellation)
        {
            try
            {
                var result = await _repos.CreateLoaiKhoaHoc(_mapper.Map<LoaiKhoaHoc>(request), cancellation);
                if (result == ErrorMessage.Failed)
                {
                    return BadRequest("Thêm thất bại");
                }
                return Ok(new LoaiKhoaHocDto()
                {
                    TenLoai = request.TenLoai
                });
            }
            catch (Exception)
            {
                return BadRequest("Thêm thất bại");
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRecord(LoaiKhoaHocUpdateRequest request, CancellationToken cancellation)
        {
            try
            {
                var result = await _repos.UpdateLoaiKhoaHoc(_mapper.Map<LoaiKhoaHoc>(request), cancellation);
                if (result == ErrorMessage.NotFindModel)
                {
                    return BadRequest("Không tìm thấy đối tượng");
                }
                return Ok(new LoaiKhoaHocDto()
                {
                    TenLoai = request.TenLoai
                });
            }
            catch (Exception)
            {
                return BadRequest("Cập nhật thất bại");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteRecord([FromQuery] LoaiKhoaHocDeleteRequest request, CancellationToken cancellation)
        {
            try
            {
                var result = await _repos.DeleteLoaiKhoaHoc(_mapper.Map<LoaiKhoaHoc>(request), cancellation);
                if (result == ErrorMessage.NotFindModel)
                {
                    return BadRequest("Không tìm thấy đối tượng");
                }
                return Ok("Xóa thành công!!!");
            }
            catch (Exception)
            {
                return BadRequest("Xóa thất bại");
            }
        }
    }
}
