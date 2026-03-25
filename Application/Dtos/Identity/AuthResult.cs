namespace Application.Dtos.Identity;

public record AuthResult
(
    bool Succeeeded,
    string Error
);