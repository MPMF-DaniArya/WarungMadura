namespace WarungMadura.DTOs;

public record createProductDTO(string ProductName, int Price, int Stock);

public record UpdateProductDTO(String ProductName, int Price, int Stock);