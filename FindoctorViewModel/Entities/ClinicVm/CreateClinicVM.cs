namespace FindoctorViewModel.Entities.ClinicVm
{
    public class CreateClinicVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartWorkTime { get; set; }
        public DateTime StoptWorkTime { get; set; }

        public int CategoryId { get; set; }
    }
}
