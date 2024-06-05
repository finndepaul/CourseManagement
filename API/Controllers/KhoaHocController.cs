using AutoMapper;
using CourseManagement.Application.DataTransferObjects.KhoaHoc;
using CourseManagement.Application.DataTransferObjects.KhoaHoc.Request;
using CourseManagement.Application.Interfaces.Repositories;
using CourseManagement.Application.ValueObjects.Pagination;
using CourseManagement.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoaHocController : ControllerBase
    {
        private readonly IKhoaHocRepos _repos;
        private readonly IMapper _mapper;

        public KhoaHocController(IKhoaHocRepos repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? name, [FromQuery] PaginationRequest request)
        {
            try
            {
                var model = await _repos.GetAll(name,request);
                //var result = model.Data.Select(x => new KhoaHocDto()
                //{
                //    TenKhoaHoc = x.TenKhoaHoc,
                //    ThoiGianHoc = x.ThoiGianHoc,
                //    GioiThieu = x.GioiThieu,
                //    NoiDung = x.NoiDung,
                //    HocPhi = x.HocPhi,
                //    SoHocVien = x.SoHocVien,
                //    SoLuongMon = x.SoLuongMon,
                //    HinhAnh = x.HinhAnh,
                //    TenLoai = x.LoaiKhoaHoc == null ? "N/a" : x.LoaiKhoaHoc.TenLoai,
                //});
                //return Ok(result);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateNew(KhoaHocCreateRequest request, CancellationToken cancellation)
        {
            try
            {
                var model = await _repos.CreateNew(_mapper.Map<KhoaHoc>(request), cancellation);
                return Ok("Thêm thành công");
            }
            catch (Exception)
            {
                return BadRequest("Thêm thất bại!!");
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRecord(KhoaHocUpdateRequest request, CancellationToken cancellation)
        {
            try
            {
                var model = await _repos.UpdateRecord(_mapper.Map<KhoaHoc>(request), cancellation);
                return Ok(request);
            }
            catch (Exception)
            {
                return BadRequest("Cập nhật thất bại!!");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteRecord([FromQuery] KhoaHocDeleteRequest request, CancellationToken cancellation)
        {
            try
            {
                var model = await _repos.DeleteRecord(_mapper.Map<KhoaHoc>(request), cancellation);
                return Ok("Xóa thành công");
            }
            catch (Exception)
            {
                return BadRequest("Xóa thất bại!!");
            }
        }

    }
}
