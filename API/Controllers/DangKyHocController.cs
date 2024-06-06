using AutoMapper;
using CourseManagement.Application.DataTransferObjects.DangKyHoc.Request;
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
    public class DangKyHocController : ControllerBase
    {
        private readonly IDangKyHocRepos _repos;
        private readonly IMapper _mapper;

        public DangKyHocController(IDangKyHocRepos repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]PaginationRequest request)
        {
            var model = await _repos.GetAll(request);
            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateNew(DangKyHocCreateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var model = await _repos.CreateDangKyKhoaHoc(_mapper.Map<DangKyHoc>(request),cancellationToken);
                if (model == ErrorMessage.Failed)
                {
                    return BadRequest("Thêm thất bại");
                }
                return Ok("Thêm thành công");
            }
            catch (Exception)
            {
                return BadRequest("Thêm thất bại");
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRecord(DangKyHocUpdateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var model = await _repos.UpdateDangKyKhoaHoc(_mapper.Map<DangKyHoc>(request), cancellationToken);
                if (model == ErrorMessage.NotFindModel)
                {
                    return BadRequest("Không tìm thấy đối tượng");
                }
                else if(model == ErrorMessage.Failed)
                {
                    return BadRequest("Cập nhật thất bại");
                }
                return Ok("Cập nhật thành công");
            }
            catch (Exception)
            {
                return BadRequest("Cập nhật thất bại");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteRecord([FromQuery] DangKyHocDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var model = await _repos.DeleteDangKyKhoaHoc(_mapper.Map<DangKyHoc>(request), cancellationToken);
                if (model == ErrorMessage.NotFindModel)
                {
                    return BadRequest("Không tìm thấy đối tượng");
                }
                else if (model == ErrorMessage.Failed)
                {
                    return BadRequest("Xóa thất bại");
                }
                return Ok("Xóa thành công");
            }
            catch (Exception)
            {
                return BadRequest("Xóa thất bại");
            }
        }
    }
}
