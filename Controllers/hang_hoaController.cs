using KTGK_1.Data;
using KTGK_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KTGK_1.Controllers
{
    [Route("api/hang_hoa")]
    [ApiController]
    public class hang_hoaApiController : ControllerBase
    {
        private readonly Context _context;

        public hang_hoaApiController(Context context)
        {
            _context = context;
        }

        // GET: api/hang_hoa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<hang_hoa>>> GetAll()
        {
            return await _context.Goods.ToListAsync();
        }

        // GET: api/hang_hoa/mahang_hoa
        [HttpGet("{id}")]
        public async Task<ActionResult<hang_hoa>> GetById(string id)
        {
            var hang_hoa = await _context.Goods.FindAsync(id);
            if (hang_hoa == null)
            {
                return NotFound();
            }
            return hang_hoa;
        }

        // POST: api/hang_hoa
        [HttpPost]
        public async Task<ActionResult<hang_hoa>> Create(hang_hoa hang_hoa)
        {
            _context.Goods.Add(hang_hoa);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = hang_hoa.ma_hanghoa }, hang_hoa);
        }

        // PUT: api/hang_hoa/mahang_hoa
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, hang_hoa hang_hoa)
        {
            if (id != hang_hoa.ma_hanghoa)
            {
                return BadRequest();
            }

            _context.Entry(hang_hoa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/hang_hoa/mahang_hoa
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var hang_hoa = await _context.Goods.FindAsync(id);
            if (hang_hoa == null)
            {
                return NotFound();
            }

            _context.Goods.Remove(hang_hoa);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        //Patch: api/ghichu
        [HttpPatch("ghichu/{id}")]
        public async Task<IActionResult> UpdateGhiChu(string id, [FromBody] string ghiChu)
        {
            var hanghoa = await _context.Goods.FindAsync(id);
            if (hanghoa == null)
            {
                return NotFound();
            }

            hanghoa.ghi_chu = ghiChu;
            await _context.SaveChangesAsync();

            return Ok(hanghoa);
        }
    }
}
