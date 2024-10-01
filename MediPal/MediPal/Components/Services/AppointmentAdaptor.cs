using MediPal.Data;
using MediPal.Models;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;
using Syncfusion.Blazor.Schedule.Internal;

namespace MediPal.Components.Services
{
    public class AppointmentAdaptor : DataAdaptor
    {
        private readonly IAppointmentService _appService;
        public AppointmentAdaptor(IAppointmentService appService)
        {
            _appService = appService;
        }

        List<Appointment>? Appointments;

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string userId)
        {
            Appointments = await _appService.GetAppointmentsByUserIdAsync(userId);
            return dataManagerRequest.RequiresCounts ? new DataResult() { Result = Appointments, Count = Appointments.Count() } : Appointments;
        }

        public async override Task<object> InsertAsync(DataManager dataManager, object data, string key)
        {
            await _appService.AddAppointmentAsync(data as Appointment);
            return data;
        }

        public async override Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)
        {
            await _appService.UpdateAppointmentAsync(data as Appointment);
            return data;
        }

        public async override Task<object> RemoveAsync(DataManager dataManager, object data, string keyField, string key) //triggers on appointment deletion through public method DeleteEvent
        {
            var app = await _appService.GetAppointmentByIdAsync((int)data);
            await _appService.DeleteAppointmentAsync(app);
            return data;
        }

        public async override Task<object> BatchUpdateAsync(DataManager dataManager, object changedRecords, object addedRecords, object deletedRecords, string keyField, string key, int? dropIndex)
        {
            await Task.Delay(100); //To mimic asynchronous operation, we delayed this operation using Task.Delay
            object records = deletedRecords;
            List<Appointment>? deleteData = deletedRecords as List<Appointment>;
            if (deleteData != null)
            {
                foreach (var data in deleteData)
                {
                    await _appService.DeleteAppointmentAsync(data as Appointment);
                }
            }
            List<Appointment>? addData = addedRecords as List<Appointment>;
            if (addData != null)
            {
                foreach (var data in addData)
                {
                    await _appService.AddAppointmentAsync(data as Appointment);
                    records = addedRecords;
                }
            }
            List<Appointment>? updateData = changedRecords as List<Appointment>;
            if (updateData != null)
            {
                foreach (var data in updateData)
                {
                    await _appService.UpdateAppointmentAsync(data as Appointment);
                    records = changedRecords;
                }
            }
            return records;

        }
    }
}
