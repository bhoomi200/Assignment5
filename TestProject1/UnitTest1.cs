using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using StudentTest.Controllers;
using StudentTest.Models;
using StudentTest.Services;

namespace TestProject1

{
    public class UnitTest1
    {
        private readonly Mock<IStudentTest> studentService;
        private Fixture _fixture;
        private StudentController _controller;
        public UnitTest1()
        {
            _fixture = new Fixture();
            studentService = new Mock<IStudentTest>();
        }
        [Fact]
        public async Task Get_Student_returnsOK()
        {
            var studentList = _fixture.CreateMany<Student>(3).ToList();
            studentService.Setup(x => x.GetStudents()).Returns(studentList);
            _controller = new StudentController(studentService.Object);
            var result = await _controller.GetStudents();
            var obj = result as ObjectResult;
            Assert.Equal(200, obj.StatusCode);

        }
        [Fact]
        public async Task Get_StudentbyId_returnsOK()
        {
            var studentList = _fixture.Create<Student>(); 
            studentService.Setup(x => x.GetStudent(1)).Returns(studentList);
            _controller = new StudentController(studentService.Object);
            var result = await _controller.GetStudent(1);
            var obj = result as ObjectResult;
            Assert.Equal(200, obj.StatusCode);

        }
        [Fact]
        public async Task Get_Student_ThrowException()
        {
          
            studentService.Setup(x => x.GetStudents()).Throws(new Exception());
            _controller = new StudentController(studentService.Object);
            var result = await _controller.GetStudents();
            var obj = result as ObjectResult;
            Assert.Equal(400, obj.StatusCode);

        }
        [Fact]
        public async Task Get_StudentbyId_ThrowsException()
        {
            studentService.Setup(x => x.GetStudent(2)).Throws(new Exception());
            _controller = new StudentController(studentService.Object);
            var result = await _controller.GetStudent(2);
            var obj = result as ObjectResult;
            Assert.Equal(400, obj.StatusCode);

        }
        [Fact]
        public async Task POST_Student_returnsOK()
        {
            var student = _fixture.Create<Student>();
            studentService.Setup(x => x.PostStudent(It.IsAny<Student>())).Returns(student);
            _controller = new StudentController(studentService.Object);
            var result = await _controller.PostStudent(student);
            var obj = result as ObjectResult;
            Assert.Equal(200, obj.StatusCode);

        }
        [Fact]
        public async Task POST_Student_ThrowsException()
        {
            var student = _fixture.Create<Student>();
            studentService.Setup(x => x.PostStudent(It.IsAny<Student>())).Throws(new Exception());
            _controller = new StudentController(studentService.Object);
            var result = await _controller.PostStudent(student);
            var obj = result as ObjectResult;
            Assert.Equal(400, obj.StatusCode);

        }
        [Fact]
        public async Task Put_Student_returnsOK()
        {
            var student = _fixture.Create<Student>();
            studentService.Setup(x => x.PutStudent(It.IsAny<Student>())).Returns(student);
            _controller = new StudentController(studentService.Object);
            var result = await _controller.PutStudent(student);
            var obj = result as ObjectResult;
            Assert.Equal(200, obj.StatusCode);

        }
        [Fact]
        public async Task Put_Student_ThrowsException()
        {
            var student = _fixture.Create<Student>();
            studentService.Setup(x => x.PutStudent(It.IsAny<Student>())).Throws(new Exception());
            _controller = new StudentController(studentService.Object);
            var result = await _controller.PutStudent(student);
            var obj = result as ObjectResult;
            Assert.Equal(400, obj.StatusCode);

        }
        [Fact]
        public async Task Delete_Student_returnsOK()
        {
            
            studentService.Setup(x => x.DeleteStudent(It.IsAny<int>())).Returns(true);
            _controller = new StudentController(studentService.Object);
            var result = await _controller.DeleteStudent(1);
            var obj = result as ObjectResult;
            Assert.Equal(200, obj.StatusCode);

        }
        [Fact]
        public async Task Delete_Student_ThrowsException()
        {

            studentService.Setup(x => x.DeleteStudent(It.IsAny<int>())).Throws(new Exception());
            _controller = new StudentController(studentService.Object);
            var result = await _controller.DeleteStudent(1);
            var obj = result as ObjectResult;
            Assert.Equal(400, obj.StatusCode);

        }


    }
}
