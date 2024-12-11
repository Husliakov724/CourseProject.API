using CourseProject.BLL.Models;

namespace CourseProject.BLL.Interfaces;

public interface IIndicatorService
{
    Task<Guid> CreateIndicator(IndicatorModel model);
    Task<List<IndicatorModel>> GetIndicators();
    Task DeleteIndicator(Guid id);
    Task UpdateIndicatorValue(UpdateIndicatorValueModel model);
}