using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenBots.Server.DataAccess.Repositories;
using OpenBots.Server.Model.Identity;

namespace OpenBots.Server.Business
{
    public class TermsConditionsManager : BaseManager, ITermsConditionsManager
    {
        private readonly IUserAgreementRepository _userAgreementRepository;
        private readonly IUserConsentRepository _userConsentRepository;

        public TermsConditionsManager(IUserAgreementRepository userAgreementRepository, IUserConsentRepository userConsentRepository)
        {
            _userAgreementRepository = userAgreementRepository;
            _userConsentRepository = userConsentRepository;

            _userAgreementRepository.SetContext(base.SecurityContext);
            _userConsentRepository.SetContext(base.SecurityContext);


        }

        public override void SetContext(UserSecurityContext userSecurityContext)
        {

            _userAgreementRepository.SetContext(userSecurityContext);
            _userConsentRepository.SetContext(userSecurityContext);
            base.SetContext(userSecurityContext);
        }


        public async Task<UserAgreement> GetUserAgreement()
        {
            return _userAgreementRepository.Find(null, p => p.EffectiveOnUTC <= DateTime.UtcNow && p.ExpiresOnUTC >= DateTime.UtcNow, i => i.Version, Model.Core.OrderByDirectionType.Descending)?.Items?.FirstOrDefault();
        }

        public async Task<bool> IsAccepted(Guid userAgreementId, Guid personId)
        {
            var userConsent = _userConsentRepository.Find(userAgreementId, p=>p.PersonId == personId)?.Items?.FirstOrDefault();
            if (userConsent == null) return false;

            if (userConsent.IsAccepted && userConsent.ExpiresOnUTC >= DateTime.UtcNow) return true;
            else return false;
        }
    }
}
