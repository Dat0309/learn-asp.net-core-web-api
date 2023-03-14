using Microsoft.EntityFrameworkCore;
using TitanServices.DTO;
using TitanServices.Helper;
using TitanServices.Models;

namespace TitanServices.Services
{
    public class SlideServices : ISlideServices
    {
        private readonly SliderContext _sliderContext;
        private readonly SliderTypeContext _sliderTypeContext;

        public SlideServices(SliderContext sliderContext, SliderTypeContext sliderTypeContext)
        {
            _sliderContext = sliderContext;
            _sliderTypeContext = sliderTypeContext;
        }

        public SliderModel Create(SliderModel slider)
        {
            _sliderContext.Sliders.Add(slider);
            _sliderContext.SaveChanges();
            return slider;
        }

        public IEnumerable<SliderModel> createsMany()
        {
            var sliders = new SliderModel[]
            {
                new SliderModel{Title = "INSPIRE YOUR WORK",Description="Founded on trust and experience, by a professional team, with a big vision and mission to provide the best services to our clients.",
                Image="https://www.titancorpvn.com/uploads/banners/home-banner-1.jpg",Url="",
                CreateAt=DateTime.Now,SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "BANNER")._id},
                new SliderModel{Title = "COMPREHENSIVE INNOVATIONS",Description="A dedicated and professional team that offers a wide range of advanced solution for offshore software testing and comprehensive development services.",
                Image="https://www.titancorpvn.com/uploads/banners/home-banner-2.jpg",Url="",
                CreateAt=DateTime.Now,SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "BANNER")._id},
                new SliderModel{Title = "ADVANCED SOLUTION FOR INNOVATIONS",Description="Always hunger for new idea creation, we incubate good ideas by providing facilities for product development and environment where creativity leverages our skills and services.",
                Image="https://www.titancorpvn.com/uploads/banners/home-banner-4.jpg",Url="",
                CreateAt=DateTime.Now,SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "BANNER")._id},
                new SliderModel{Title = "\"INSPIRE\" WORKING ENVIRONMENT",Description="Our friendly, challenging, and collaborative environment creates enjoy valuable benefits and sharing ownership.",
                Image="https://www.titancorpvn.com/uploads/banners/home-banner-3.jpg",Url="",
                CreateAt=DateTime.Now,SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "BANNER")._id},

                new SliderModel{Title = "SOFTWARE DEVELOPMENT",Description="Develop software applications from business ideas to deployment, develop based on product definition, the initial designs, or develop modules with multiple teams for concurrent development thus reducing time to market.",
                Image="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADYAAABICAYAAAC9bQZsAAABS2lUWHRYTUw6Y29tLmFkb2JlLnhtcAAAAAAAPD94cGFja2V0IGJlZ2luPSLvu78iIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4KPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iQWRvYmUgWE1QIENvcmUgNS42LWMxNDIgNzkuMTYwOTI0LCAyMDE3LzA3LzEzLTAxOjA2OjM5ICAgICAgICAiPgogPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4KICA8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIi8+CiA8L3JkZjpSREY+CjwveDp4bXBtZXRhPgo8P3hwYWNrZXQgZW5kPSJyIj8+nhxg7wAAA5ZJREFUaIHtm6ty20AUhr+4JYUSKU8eQe0bJFAwBX0Ae0RKHRgY0xCN9QKZsaFgQsviR6h5iAxb1gKtGlneq66Wx/9MxmPF2ey35+zZc3bXFwB+lM6BKXBJv7rL4nBRfuBH6V9gByRZHN6ZGri/v5c+nwioB/qH0skD5n6UvvpR6tVpYEJuqWNVADzXgZtwXJaSqRbcpKPOtC1nuLGAgSPcmMDAAW5sYGAJN0YwsIAbKxgIuMe3QAo3ZjDQwI0dDBRwpwAGErhTAYMK3CmBgYCD0wMDCB7fgodTBAOYniqY93HoHlSVxeGFy+eVFXQbnTlGDQ1221XDQ4MFYs+ldV2IXaGhtQHWbTZ4LMEjED+taWhX7ExnsLHpDDY2ncHGpiHAtsAV8A1IxPvWNcQCvc7icEsOtAbwozQAVrR4QDKExTbVB1kcbsjPxFpT72BZHB7khMJiowZTJbrXbf+jvsFeFM9br8sGB/Oj9JKWM3toDrYBfGBm81kRDauqumEi9j2SJh1rArYBbrI43GVxmGCGU7lhGSzJ4nAGIF5rw9UFe0FAFQ8s4EyB4z9Uqc0ZYLzrIVMdsCSLwz2oUkcS5JbZibVqT36U3vIe5qUA4oKLjavvyRXsYFTL8qN0ijx0q6xVDhoPqnYtXX1PLmAmqDmwVPz6wFpC5TA/9aNUefzqCmcLdmeAWqIZcSQWE2G+mhteozlbFnBfyO9aaWUDNqte5Cp1zhNQumtLL7L5iHpRLg7OpWubmKs3GOBMYDMxSgcSo/qM+S6WTZivqjGcCUy3iXmNXcYgyzY8zPmhhybVEnCqQTOC6fx9TT6ZdS6xlYV57JJe7X1FMQWU4CYw7UUR4aY6l6ibzc8sgpV2CtgEjwD4VdPfbcJ8Vdp57UfpCos7lrbh3sM8ma+ogDgWlTvyNM0UrKxKHJcF2gS3I7dckcG7uuFNFofSYFCCsi5vXFOqAs5m8rsWldJ5XAcK6iXBBdyen5c6UGQTrkXlquoN4v2r5m+UalKPLQs4yajaFpVl7bm6eC0PlJOa7isuhRWqi3WdbAPe4RbAnAY7V21smMrOkJvsRnnoE2ordbGZY1NUdq4uwGyKys7VBVidbKN1dQGmCvO9fiOjC7CVH6XzyprUq7Wg+wssW3IL9ho4oPvzsUsG+rbT+ah2bDqDjU0TOjq1H1jbCQ3PoY5UyYffr08/P339/oc8NPe61nSgLbD48Xmz+AeEBlLNoYxemAAAAABJRU5ErkJggg==",Url="",
                CreateAt=DateTime.Now,SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "WE PROVIDE")._id},
                new SliderModel{Title = "MAINTENANCE AND SUPPORT",Description="Maintain, enhance, and develop new features of existing software applications. We also provide services to migrate from the legacy systems to new technologies to help improve performance and add benefits to the client's businesses.",
                Image="data:image/png;base64,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",Url="",
                CreateAt=DateTime.Now,SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "WE PROVIDE")._id},
                new SliderModel{Title = "SOFTWARE TESTING",Description="Provide all kind of testing services including automation tool development, enhancement and execution to assure the quality of our client’s products.",
                Image="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADYAAABICAYAAAC9bQZsAAABS2lUWHRYTUw6Y29tLmFkb2JlLnhtcAAAAAAAPD94cGFja2V0IGJlZ2luPSLvu78iIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4KPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iQWRvYmUgWE1QIENvcmUgNS42LWMxNDIgNzkuMTYwOTI0LCAyMDE3LzA3LzEzLTAxOjA2OjM5ICAgICAgICAiPgogPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4KICA8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIi8+CiA8L3JkZjpSREY+CjwveDp4bXBtZXRhPgo8P3hwYWNrZXQgZW5kPSJyIj8+nhxg7wAAAv9JREFUaIHtm7Fum0AYgD87WSJ1gcVSx+QRkqhLR3tkzJIHcMSStR4z1msWFL9ApHZkjNcMlcwj1GvVBaYq2dqBg0IMzh0+MGfdN9knw93H+Q7+/44BLeL64Ri4AsbAqSheA0vgexx4y13ruLu7qywf7HriKlw/PAUeSIW2sQRu4sBbN62rTmzY9IR1uH54Dqx4Xwrxm5U4RitaxURPPQGOwmEO8CSO1YbuHntATSrDEcdqQ5uYmCjq/n4J6Xhais9VjMU5tKCzx65qyhfAWRx4kzjwJsCZKFM5hzI6xaqudgLM4sDLe0l8nlHdc73ssarBHxWlMkRZJHmORhwXv4hpd0r5htoprh/+Vfn9/e/8hr+4HUX5xcpv0K4ffgG+amthSkI6vkq95vqhA/yk2Qy6jdntKJoDHImK2pACOAGck8vr55fV46uoyxF1fW6hvvGPPx9fP3349TwoPCm0SXFMnaO/p95ycUw6ptrGQeOMJ8F02HGFXTEesqfZr2VOtT/d9wUrZhpWzDSsmGm0JVYXlnRGG2IJMIkD74L6SLl1dItlUhFAHHg3pLFS5+gUK0kV2EuvqYhty1VUSomQSGtaTRZZsazhc2BCWW6blGryVBuyYsVxE/FfrpdSIC9Wyq0X5HopBTCQzArVTQwlRCb3G5tSCTBv1sQNtmWcc2TF4B051w+nVE8UUhdFBZk2q8yK2arIxpJPl1KyqN7HNuT6KAVvMsGSZHIT0kmlUynZFRmVMWYUNmwxDStmGlbMNKyYaVgx0zhYMdWH4IQ065SQPgxP2XOkXIeK2Bq4KG5tcP1wTrowX7UqqjNqLnKOxNYkFbH52/0aceAlQq4qdJmLrJZ2dEfQdbtAG+8ObZODnTxUxOr+13Xl2rfDQp7eexfVCHoGLMTYymbFNrYq7YxNDZiGFTMNK2YaVsw0rJhpHLRYL8OOHVkP2dPOmZZZDtnjfqcWWQzFquNs3y3RyOx2FEVHAC+rx+eTy+tXzN+Dn7/bUnqrtg9vIzWg8m2kfym0DD8QJK5SAAAAAElFTkSuQmCC",Url="",
                CreateAt=DateTime.Now,SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "WE PROVIDE")._id},

                new SliderModel{Title = "DESKTOP DEVELOPMENT",Description="Our teams understand how to build web applications with insight UX/UI that help to strengthen the client businesses and brand awareness from the bottom-line",
                Image="https://www.titancorpvn.com/assets/images/icons/domains/desktop.png",Url="",
                CreateAt=DateTime.Now,SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "DOMAINS & TECHNOLOGIES")._id},
                new SliderModel{Title = "WEB APP DEVELOPMENT",Description="Our teams understand how to build web applications with insight UX/UI that help to strengthen the client businesses and brand awareness from the bottom-line",
                Image="https://www.titancorpvn.com/assets/images/icons/domains/web.png",Url="",
                CreateAt=DateTime.Now,SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "DOMAINS & TECHNOLOGIES")._id},
                new SliderModel{Title = "MOBILE DEVELOPMENT",Description="We have expertise in building mobile applications and mobile games on multiple platforms",
                Image="https://www.titancorpvn.com/assets/images/icons/domains/mobile.png",Url="",
                CreateAt=DateTime.Now,SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "DOMAINS & TECHNOLOGIES")._id},

                new SliderModel{Title = "CLOUD BASED DEVELOPMENT",Description="We have extensive experience in implementation of specific PaaS and SaaS",
                Image="https://www.titancorpvn.com/assets/images/icons/domains/cloud.png",Url="",
                CreateAt=DateTime.Now,SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "DOMAINS & TECHNOLOGIES")._id},
                new SliderModel{Title = "TELECOM & NETWORKING",Description="Our team has strong experience in telecom and network systems that enable us to provide both testing and development services",
                Image="https://www.titancorpvn.com/assets/images/icons/domains/network.png",Url="",
                CreateAt=DateTime.Now,SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "DOMAINS & TECHNOLOGIES")._id},
                new SliderModel{Title = "TESTING & QUALITY ASSURANCE",Description="We develop cross-platform standalone and client-server applications which run stability scalable, and also easy to convert to other architects or business models",
                Image="https://www.titancorpvn.com/assets/images/icons/domains/testing.png",Url="",
                CreateAt=DateTime.Now,SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "DOMAINS & TECHNOLOGIES")._id},
                 new SliderModel{Title = "BLOCKCHAIN DEVELOPMENT",Description="We have experiences in setting up, configuring, and developing applications based on Block chain technologies: Ethereum, De-centralized, Smart Contract, Cryptocurrency",
                Image="https://www.titancorpvn.com/assets/images/icons/domains/blockchain.png",Url="",
                CreateAt=DateTime.Now,SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "DOMAINS & TECHNOLOGIES")._id},
                new SliderModel{Title = "ARTIFICIAL INTELLIGENCE",Description="We have extensive experiences in implementation of specific solutions with AI inside: Core Machine Learning Algorithms, Unsupervised Learning, Data Preparation...",
                Image="https://www.titancorpvn.com/assets/images/icons/domains/ai.png",Url="",
                CreateAt=DateTime.Now,SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "DOMAINS & TECHNOLOGIES")._id},
                new SliderModel{Title = "ERP/CRM IMPLEMENTATION",Description="Experienced team to consult and implement ERP and CRM solutions based on Microsoft and Open Source technologies (Dynamics AX/365/NAV, OpenERP(Odoo), SugarCRM, vTiger, and so on) with following services",
                Image="https://www.titancorpvn.com/assets/images/icons/domains/crm.png",Url="",
                CreateAt=DateTime.Now,SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "DOMAINS & TECHNOLOGIES")._id},

                new SliderModel{
                    Title="SaigonX",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/http___www_saigonx_com_.jpeg",
                    Url="http://www.saigonx.com/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                new SliderModel{
                    Title="Greenpacket",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/http___www_greenpacket_com_.jpeg",
                    Url="http://www.greenpacket.com/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                new SliderModel{
                    Title="SSENSE",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/https___www_ssense_com_.jpeg",
                    Url="https://www.ssense.com/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                new SliderModel{
                    Title="GREENCOPPER",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/https___www_greencopper_com_.jpeg",
                    Url="https://www.greencopper.com/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                new SliderModel{
                    Title="BGXAI",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/https___www_bgx_ai_.jpeg",
                    Url="https://www.bgx.ai/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                new SliderModel{
                    Title="wedgenetworks",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/https___www_wedgenetworks_com_.jpeg",
                    Url="https://www.wedgenetworks.com/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                new SliderModel{
                    Title="DP",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/http___www_digitalperformance_de_.jpeg",
                    Url="http://www.digitalperformance.de/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                new SliderModel{
                    Title="MinkGeek",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/http___mindgeek_com_.jpeg",
                    Url="http://mindgeek.com/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                new SliderModel{
                    Title="CollectiveClarity",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/http___www_collectiveclarity_net_.jpeg",
                    Url="http://www.collectiveclarity.net/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                 new SliderModel{
                    Title="superhippo",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/http___superhippo_com_.jpeg",
                    Url="http://superhippo.com/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                 new SliderModel{
                    Title="Trafficpartner",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/https___www_etnasoft_com_.jpeg",
                    Url="https://www.trafficpartner.com/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                 new SliderModel{
                    Title="ewerk",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/https___www_ewerk_com_.jpeg",
                    Url="https://www.ewerk.com/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                 new SliderModel{
                    Title="ktcc",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/http___www_ktcc_co_jp_.jpeg",
                    Url="http://www.ktcc.co.jp/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                 new SliderModel{
                    Title="Frogasia",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/https___frogasia_com_.jpeg",
                    Url="https://frogasia.com/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                 new SliderModel{
                    Title="TVT",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/http___www_tpf_com_au_.jpeg",
                    Url="https://tvt.biz/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                 new SliderModel{
                    Title="sssmine",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/http___www_sssmine_com_.jpeg",
                    Url="http://www.sssmine.com/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                 new SliderModel{
                    Title="empiregroup",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/http___www_ecopharma_com_vn_.jpeg",
                    Url="http://empiregroup.vn/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },


                 new SliderModel
                 {
                     Title="DR. TIM PARKER*Chief Technical Officer",
                     Description="We have worked with Titan Technology for the last three years on a complex and evolving software product. We are delighted with the quality of the deliverables, the enthusiasm of the team, and the dedication to our project. We look forward to continuing this excellent relationship in the years to come, and I strongly recommend Titan Technology as a software outsourcing provider.",
                     Image="https://www.titancorpvn.com/uploads/documents/testimonials/Director_of_Application_Development.png",
                     CreateAt=DateTime.Now,
                     SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "CUSTOMER TESTIMONIALS")._id,
                 },
                  new SliderModel
                 {
                     Title="THOMAS SANTONJA*Director of Application Development",
                     Description="A professional and dedicated team with a spirit of delivery. Successfully worked along us for delivery of years of features.",
                     Image="https://www.titancorpvn.com/uploads/documents/testimonials/Director_of_Application_Development.png",
                     CreateAt=DateTime.Now,
                     SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "CUSTOMER TESTIMONIALS")._id,
                 },
                  new SliderModel
                 {
                     Title="VALERY KHVATOV*VP of Technology",
                     Description="The work of Titan Technology is distinguished by high professionalism and initiative. It is a wonderful combination for a tech company. Our project consisted of building a mobile app for a blockchain platform. The team asked many right questions throughout the development process and in the end the app was even better and more thought out than in our initial view. And to add, we were on budget and schedule. The quality of development is very high as well. Another very positive factor is communication. It is of utmost importance for a remote team. We are delighted to recommend working with Titan Technology, a very mature and responsible company.",
                     Image="https://www.titancorpvn.com/uploads/documents/testimonials/VP_of_Technology.png",
                     CreateAt=DateTime.Now,
                     SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "CUSTOMER TESTIMONIALS")._id,
                 },
                  new SliderModel
                 {
                     Title="HONGWEN ZHANG, PH.D*CEO & CTO (co-founder)",
                     Description="Wedge Networks Inc, based in Canada, is a leader in Real-time Threat Prevention for the cloud networks. Our products and services are distributed world-wide. Product quality, reliability, and supportability are critical to our success. That’s why we partnered with Thanh Nguyen and his Titan team. Working as an extended team of Wedge Networks, the Titan team provided world class QA and product support services for us. The team is highly skilled, dependable, and flexible. The successes of our recent product launches are testaments of their significant contributions.",
                     Image="https://www.titancorpvn.com/uploads/documents/testimonials/CEO_&_CTO_(co-founder).png",
                     CreateAt=DateTime.Now,
                     SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "CUSTOMER TESTIMONIALS")._id,
                 },
                  new SliderModel
                 {
                     Title="CHRIS HENNIGFELD*Project Manager",
                     Description="We greatly appreciate the reliable and cost-effective team Titan has provided to us to develop and maintain one of our systems with over a thousand internal users for several years.",
                     Image="https://www.titancorpvn.com/uploads/documents/testimonials/Project_Manager.png",
                     CreateAt=DateTime.Now,
                     SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "CUSTOMER TESTIMONIALS")._id,
                 },
                  new SliderModel
                 {
                     Title="STEPHEN COLE*CEO",
                     Description="In these challenging times, I wanted to say thank you for the outstanding effort and service we have experienced with Titan.They are professionals who really take customer care to the highest levels.We will definitely be using Titan services for our new upcoming projects. Your Company is exemplary in the world of software development and project management. Our projects have always been on time and within budget at Ai6 and Collective Clarity",
                     Image="https://www.titancorpvn.com/uploads/documents/testimonials/CEO.png",
                     CreateAt=DateTime.Now,
                     SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "CUSTOMER TESTIMONIALS")._id,
                 },

                  new SliderModel
                  {
                      Title="",
                      Image="https://www.titancorpvn.com/uploads/documents/recognized/Award_08.png",
                      CreateAt=DateTime.Now,
                      SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "As Recognized By")._id,
                      Url="https://www.certipedia.com/quality_marks/9000008850?locale=en"
                  },
                  new SliderModel
                  {
                      Title="",
                      Image="https://www.titancorpvn.com/uploads/documents/recognized/Award_01.png",
                      CreateAt=DateTime.Now,
                      SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "CUSTOMER TESTIMONIALS")._id,
                      Url="https://www.goodfirms.co/company/titan-technology-corporation/focus"
                  },
                  new SliderModel
                  {
                      Title="",
                      Image="https://www.titancorpvn.com/uploads/documents/recognized/Award_03.png",
                      CreateAt=DateTime.Now,
                      SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "CUSTOMER TESTIMONIALS")._id,
                      Url="http://vinasa.org.vn/Default.aspx?sname=vinasa&sid=4&pageid=3074&catid=4199&catname=gioi-thieu"
                  },
                  new SliderModel
                  {
                      Title="",
                      Image="https://www.titancorpvn.com/uploads/documents/recognized/Award_04.png",
                      CreateAt=DateTime.Now,
                      SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "CUSTOMER TESTIMONIALS")._id,
                      Url="http://vnito2015.vnito.org/award/"
                  },
                  new SliderModel
                  {
                      Title="",
                      Image="https://www.titancorpvn.com/uploads/documents/recognized/Award_05.png",
                      CreateAt=DateTime.Now,
                      SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "CUSTOMER TESTIMONIALS")._id,
                      Url="http://www.phunhuan.hochiminhcity.gov.vn/Pages/default.aspx"
                  },
                  new SliderModel
                  {
                      Title="",
                      Image="https://www.titancorpvn.com/uploads/documents/recognized/Award_02.png",
                      CreateAt=DateTime.Now,
                      SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "CUSTOMER TESTIMONIALS")._id,
                      Url="http://vjc.org.vn/japanictday/vi/homepagevn/"
                  },
                  new SliderModel
                  {
                      Title="",
                      Image="https://www.titancorpvn.com/uploads/documents/recognized/Award_06.png",
                      CreateAt=DateTime.Now,
                      SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "CUSTOMER TESTIMONIALS")._id,
                      Url="https://hca.org.vn/post/13266"
                  },
                  new SliderModel
                  {
                      Title="",
                      Image="https://www.titancorpvn.com/uploads/documents/recognized/Award_07.png",
                      CreateAt=DateTime.Now,
                      SlideTypeID=_sliderTypeContext.SliderTypes.Single( i => i.Title == "CUSTOMER TESTIMONIALS")._id,
                      Url="https://www.jetro.go.jp/en/"
                  },

            };
            foreach (var slider in sliders)
            {
                _sliderContext.Sliders.Add(slider);
            }
            _sliderContext.SaveChanges();
            return sliders;
        }

        public void Delete(string id)
        {
            var slider = _sliderContext.Sliders.Find(id);
            if (slider != null)
            {
                _sliderContext.Sliders.Remove(slider);
                _sliderContext.SaveChanges();
            }
        }

        public IEnumerable<SliderModel> GetAll()
        {
            if(_sliderContext.Sliders == null) return Enumerable.Empty<SliderModel>();
            return _sliderContext.Sliders;
        }

        public SliderModel GetById(string id)
        {
            return _sliderContext.Sliders.Find(id);
        }

        public void Update(SliderModel sliderParam)
        {
            var slider = _sliderContext.Sliders.Find(sliderParam._id);
            if (slider == null)
                throw new AppException("Slider not found");

            slider = sliderParam;
            _sliderContext.Sliders.Update(slider);
            _sliderContext.SaveChanges();
        }
    }
}
