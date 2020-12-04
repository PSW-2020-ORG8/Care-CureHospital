using Backend.Model.PatientDoctor;
using Backend.Repository.MySQL;
using Backend.Repository.MySQL.Stream;
using Repository.IDSequencer;

namespace Backend.Repository.DoctorRepository
{
    public class EPrescriptionRepository : MySQLRepository<EPrescription, int>, IEPrescriptionRepository
    {
        private static EPrescriptionRepository instance;
        public static EPrescriptionRepository Instance()
        {
            if (instance == null)
            {
                instance = new EPrescriptionRepository(new MySQLStream<EPrescription>(), new IntSequencer());
            }
            return instance;
        }

        public EPrescriptionRepository(IMySQLStream<EPrescription> stream, ISequencer<int> sequencer)
            : base(stream, sequencer)
        {
        }
    }

}
