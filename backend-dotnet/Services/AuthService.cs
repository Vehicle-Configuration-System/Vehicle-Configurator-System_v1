using backend_dotnet.Data;
using backend_dotnet.DTO;
using backend_dotnet.Helpers;
using backend_dotnet.Models;
using backend_dotnet.Services;
using Microsoft.EntityFrameworkCore;
using backend_dotnet.DTO;
using backend_dotnet.Services;
using Microsoft.AspNetCore.Mvc;


namespace backend_dotnet.Services
{
    public class AuthService : IAuthService
    {

        private readonly ApplicationDbContext _context;
        private readonly PasswordHasher _passwordHasher;
        private readonly IJwtService _jwtService;



        public AuthService(
            ApplicationDbContext context,
            PasswordHasher passwordHasher,
            IJwtService jwtService)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }



        // REGISTER

        public async Task Register(RegisterRequestDto request)
        {

            var existingUser = await _context.Users
                .FirstOrDefaultAsync(
                    x => x.Email == request.Email);


            if (existingUser != null)
            {
                throw new Exception(
                    "Email already registered");
            }



            User user = new User
            {

                CompanyName = request.CompanyName,

                CompanyAddress = request.CompanyAddress,

                Username = request.Username,

                Email = request.Email,

                Mobile = request.Mobile,

                GstNo = request.GstNo,

                RegistrationNo = request.RegistrationNo,

                StNo = request.StNo,

                VatNo = request.VatNo,

                TaxNo = request.TaxNo,

                Designation = request.Designation,


                // PASSWORD HASHING HERE
                Password =
                _passwordHasher.HashPassword(
                    request.Password),


                Role = "ROLE_USER"

            };


            _context.Users.Add(user);


            await _context.SaveChangesAsync();

        }




        // LOGIN

        public async Task<LoginResponseDto> Login(
            LoginRequestDto request)
        {

            var user = await _context.Users
                .FirstOrDefaultAsync(
                    x => x.Email == request.Email);



            if (user == null)
            {
                throw new Exception(
                    "Invalid email");
            }



            bool passwordValid =
                _passwordHasher.VerifyPassword(
                    request.Password,
                    user.Password);



            if (!passwordValid)
            {
                throw new Exception(
                    "Invalid password");
            }




            // Generate JWT Token

            string token =
                _jwtService.GenerateToken(user);




            return new LoginResponseDto
            {
                Success = true,

                Message = "Login successful",

                Token = token,

                UserId = user.UserId,

                Username = user.Username,

                Email = user.Email,

                Role = user.Role

            };

        }

    }
}
