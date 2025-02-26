namespace Application.Interfaces
{
    public interface IService<TEntity, TCreateDto, TUpdateDto, TDto> 
        where TEntity : class
    {
        Task<TDto> CreateAsync(TCreateDto createDto);
        Task<TDto> GetByIdAsync(Guid id);
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> UpdateAsync(TUpdateDto updateDto);
        Task<bool> DeleteAsync(Guid id);
    }
}