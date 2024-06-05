using AutoMapper;
using CourseManagement.Application.DataTransferObjects.TinhTrangHoc;
using CourseManagement.Application.DataTransferObjects.TinhTrangHoc.Request;
using CourseManagement.Application.Interfaces.Repositories;
using CourseManagement.Domain.Entities;
using CourseManagement.Domain.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TinhTrangHocController : ControllerBase
    {
        private readonly ITinhTrangHocRepos _repos;
        private readonly IMapper _mapper;

        public TinhTrangHocController(ITinhTrangHocRepos repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var model = await _repos.GetAll();
            var result = model.Select(x => new TinhTrangHocDto()
            {
                TenTinhTrang = x.TenTinhTrang,
            });
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateNew(TinhTrangHocCreateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var model = await _repos.CreateTinhTrangHoc(_mapper.Map<TinhTrangHoc>(request), cancellationToken);
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
        public async Task<IActionResult> UpdateRecord(TinhTrangHocUpdateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var model = await _repos.UpdateTinhTrangHoc(_mapper.Map<TinhTrangHoc>(request), cancellationToken);
                if (model == ErrorMessage.NotFindModel)
                {
                    return BadRequest("Không tìm thấy đối tượng");
                }
                else if (model == ErrorMessage.Failed)
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
        public async Task<IActionResult> DeleteRecord([FromQuery]TinhTrangHocDeleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var model = await _repos.DeleteTinhTrangHoc(_mapper.Map<TinhTrangHoc>(request), cancellationToken);
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
