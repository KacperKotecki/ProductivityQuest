using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using static Google.Apis.Calendar.v3.CalendarService;
namespace Productivity_Quest_1._0.Google_Calendar
{
    internal class GoogleAuthService
    {

        private const string CredentialsPath = "GoogleSync/credentials.json";
        private const string TokenFolder = "token_store";
        private static readonly string[] Scopes = { CalendarService.Scope.Calendar };
        private const string ApplicationName = "Productivity Quest";

        public async Task<CalendarService> GetCalendarServiceAsync()
        {
            try
            {
                if (!File.Exists(CredentialsPath))
                {
                    throw new FileNotFoundException("Brak pliku credentials.json. Skopiuj plik z Google Cloud Console.", CredentialsPath);
                }

             

                using (var stream = new FileStream(CredentialsPath, FileMode.Open, FileAccess.Read))
                {
                    var credPath = TokenFolder;
                    var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(stream).Secrets, // Updated to use FromStream
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)
                    );

                    // Utworzenie instancji CalendarService
                    return new CalendarService(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = ApplicationName,
                    });
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"Brak pliku z danymi logowania:\n{ex.FileName}\n\nPobierz credentials.json z Google Cloud Console.","Błąd autoryzacji Google",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            catch (System.Net.Http.HttpRequestException)
            {
                MessageBox.Show(
                    "Brak połączenia z internetem. Sprawdź swoje połączenie i spróbuj ponownie.",
                    "Błąd połączenia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił nieoczekiwany błąd podczas autoryzacji Google:\n{ex.Message}",
                    "Błąd autoryzacji",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return null;
        }


    }
}
