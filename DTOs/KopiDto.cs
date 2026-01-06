namespace WarungMadura.DTOs;

public record createProductDTO(string ProductName, int Price, int Stock);

public record UpdateProductDTO(string ProductName, int Price, int Stock);