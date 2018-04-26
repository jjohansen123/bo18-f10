using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BachelorDataAccess;
using BachelorModel;

namespace BachelorAPI2.Controllers
{
    public class NodesController : ApiController
    {
        private BachelorContext db = new BachelorContext();

        // GET: api/Nodes
        public IQueryable<Node> GetNodes()
        {
            return db.Nodes;
        }

        // GET: api/Nodes/5
        [ResponseType(typeof(Node))]
        public async Task<IHttpActionResult> GetNode(int id)
        {
            Node node = await db.Nodes.FindAsync(id);
            if (node == null)
            {
                return NotFound();
            }

            return Ok(node);
        }

        // PUT: api/Nodes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNode(int id, Node node)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != node.LocalID)
            {
                return BadRequest();
            }

            db.Entry(node).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NodeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Nodes
        [ResponseType(typeof(Node))]
        public async Task<IHttpActionResult> PostNode(Node node)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Nodes.Add(node);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = node.LocalID }, node);
        }

        // DELETE: api/Nodes/5
        [ResponseType(typeof(Node))]
        public async Task<IHttpActionResult> DeleteNode(int id)
        {
            Node node = await db.Nodes.FindAsync(id);
            if (node == null)
            {
                return NotFound();
            }

            db.Nodes.Remove(node);
            await db.SaveChangesAsync();

            return Ok(node);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NodeExists(int id)
        {
            return db.Nodes.Count(e => e.LocalID == id) > 0;
        }
    }
}
/*

                //using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DonauConnection"].ConnectionString))
                {
                    var cmd = new SqlCommand("INSERT INTO CourseStudent VALUES(@CourseId, @StudentId); ", conn);
                    cmd.Parameters.Add(new SqlParameter("@CourseId", courseId));
                    cmd.Parameters.Add(new SqlParameter("@StudentId", studentId));

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected != 1)
                        return Conflict();
                }*/