using TitanServices.DTO;
using TitanServices.Models;

namespace TitanServices.Data
{
    public class DBInitialize
    {
        public static void Initialize(ProjectContext context)
        {
            if (context.Sliders.Any())
                return;
            var sliderTypes = new SliderType[]
            {
                new SliderType{Title="BANNER",Description="Banner"},
                new SliderType{Title="DOMAINS & TECHNOLOGIES", Description="DOMAINS & TECHNOLOGIES"},
                new SliderType{Title="WE PROVIDE", Description="Professional and trusted services with cost-effective and exceptional expertise to deal with any complexities in scalable projects"},
                new SliderType{Title="OUR CLIENTS", Description="OUR CLIENTS"},
                new SliderType{Title="CUSTOMER TESTIMONIALS",Description="We deeply appreciate all feedbacks from our customers and keep those as realistic results of high-quality service in Titan"},
                new SliderType{Title="As Recognized By", Description="As Recognized By"}
            };

            foreach ( var sliderType in sliderTypes )
            {
                context.SliderTypes.Add(sliderType);
            }
            context.SaveChanges();

            var postTypes = new PostType[]
            {
                new PostType{Title="NEWS & EVENTS"},
                new PostType{Title="BLOGS"},
            };
            foreach( var postType in postTypes)
            {
                context.PostTypes.Add(postType);
            }
            context.SaveChanges();

            var sliders = new SliderModel[]
            {
                new SliderModel{Title = "INSPIRE YOUR WORK",Description="Founded on trust and experience, by a professional team, with a big vision and mission to provide the best services to our clients.",
                Image="https://www.titancorpvn.com/uploads/banners/home-banner-1.jpg",Url="",
                CreateAt=DateTime.Now,SlideTypeID=sliderTypes.Single( i => i.Title == "BANNER")._id},
                new SliderModel{Title = "COMPREHENSIVE INNOVATIONS",Description="A dedicated and professional team that offers a wide range of advanced solution for offshore software testing and comprehensive development services.",
                Image="https://www.titancorpvn.com/uploads/banners/home-banner-2.jpg",Url="",
                CreateAt=DateTime.Now,SlideTypeID=sliderTypes.Single( i => i.Title == "BANNER")._id},
                new SliderModel{Title = "ADVANCED SOLUTION FOR INNOVATIONS",Description="Always hunger for new idea creation, we incubate good ideas by providing facilities for product development and environment where creativity leverages our skills and services.",
                Image="https://www.titancorpvn.com/uploads/banners/home-banner-4.jpg",Url="",
                CreateAt=DateTime.Now,SlideTypeID=sliderTypes.Single( i => i.Title == "BANNER")._id},
                new SliderModel{Title = "\"INSPIRE\" WORKING ENVIRONMENT",Description="Our friendly, challenging, and collaborative environment creates enjoy valuable benefits and sharing ownership.",
                Image="https://www.titancorpvn.com/uploads/banners/home-banner-3.jpg",Url="",
                CreateAt=DateTime.Now,SlideTypeID=sliderTypes.Single( i => i.Title == "BANNER")._id},

                new SliderModel{Title = "SOFTWARE DEVELOPMENT",Description="Develop software applications from business ideas to deployment, develop based on product definition, the initial designs, or develop modules with multiple teams for concurrent development thus reducing time to market.",
                Image="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADYAAABICAYAAAC9bQZsAAABS2lUWHRYTUw6Y29tLmFkb2JlLnhtcAAAAAAAPD94cGFja2V0IGJlZ2luPSLvu78iIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4KPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iQWRvYmUgWE1QIENvcmUgNS42LWMxNDIgNzkuMTYwOTI0LCAyMDE3LzA3LzEzLTAxOjA2OjM5ICAgICAgICAiPgogPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4KICA8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIi8+CiA8L3JkZjpSREY+CjwveDp4bXBtZXRhPgo8P3hwYWNrZXQgZW5kPSJyIj8+nhxg7wAAA5ZJREFUaIHtm6ty20AUhr+4JYUSKU8eQe0bJFAwBX0Ae0RKHRgY0xCN9QKZsaFgQsviR6h5iAxb1gKtGlneq66Wx/9MxmPF2ey35+zZc3bXFwB+lM6BKXBJv7rL4nBRfuBH6V9gByRZHN6ZGri/v5c+nwioB/qH0skD5n6UvvpR6tVpYEJuqWNVADzXgZtwXJaSqRbcpKPOtC1nuLGAgSPcmMDAAW5sYGAJN0YwsIAbKxgIuMe3QAo3ZjDQwI0dDBRwpwAGErhTAYMK3CmBgYCD0wMDCB7fgodTBAOYniqY93HoHlSVxeGFy+eVFXQbnTlGDQ1221XDQ4MFYs+ldV2IXaGhtQHWbTZ4LMEjED+taWhX7ExnsLHpDDY2ncHGpiHAtsAV8A1IxPvWNcQCvc7icEsOtAbwozQAVrR4QDKExTbVB1kcbsjPxFpT72BZHB7khMJiowZTJbrXbf+jvsFeFM9br8sGB/Oj9JKWM3toDrYBfGBm81kRDauqumEi9j2SJh1rArYBbrI43GVxmGCGU7lhGSzJ4nAGIF5rw9UFe0FAFQ8s4EyB4z9Uqc0ZYLzrIVMdsCSLwz2oUkcS5JbZibVqT36U3vIe5qUA4oKLjavvyRXsYFTL8qN0ijx0q6xVDhoPqnYtXX1PLmAmqDmwVPz6wFpC5TA/9aNUefzqCmcLdmeAWqIZcSQWE2G+mhteozlbFnBfyO9aaWUDNqte5Cp1zhNQumtLL7L5iHpRLg7OpWubmKs3GOBMYDMxSgcSo/qM+S6WTZivqjGcCUy3iXmNXcYgyzY8zPmhhybVEnCqQTOC6fx9TT6ZdS6xlYV57JJe7X1FMQWU4CYw7UUR4aY6l6ibzc8sgpV2CtgEjwD4VdPfbcJ8Vdp57UfpCos7lrbh3sM8ma+ogDgWlTvyNM0UrKxKHJcF2gS3I7dckcG7uuFNFofSYFCCsi5vXFOqAs5m8rsWldJ5XAcK6iXBBdyen5c6UGQTrkXlquoN4v2r5m+UalKPLQs4yajaFpVl7bm6eC0PlJOa7isuhRWqi3WdbAPe4RbAnAY7V21smMrOkJvsRnnoE2ordbGZY1NUdq4uwGyKys7VBVidbKN1dQGmCvO9fiOjC7CVH6XzyprUq7Wg+wssW3IL9ho4oPvzsUsG+rbT+ah2bDqDjU0TOjq1H1jbCQ3PoY5UyYffr08/P339/oc8NPe61nSgLbD48Xmz+AeEBlLNoYxemAAAAABJRU5ErkJggg==",Url="",
                CreateAt=DateTime.Now,SlideTypeID=sliderTypes.Single( i => i.Title == "WE PROVIDE")._id},
                new SliderModel{Title = "MAINTENANCE AND SUPPORT",Description="Maintain, enhance, and develop new features of existing software applications. We also provide services to migrate from the legacy systems to new technologies to help improve performance and add benefits to the client's businesses.",
                Image="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAFsAAABICAYAAACZdImsAAABS2lUWHRYTUw6Y29tLmFkb2JlLnhtcAAAAAAAPD94cGFja2V0IGJlZ2luPSLvu78iIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4KPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iQWRvYmUgWE1QIENvcmUgNS42LWMxNDIgNzkuMTYwOTI0LCAyMDE3LzA3LzEzLTAxOjA2OjM5ICAgICAgICAiPgogPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4KICA8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIi8+CiA8L3JkZjpSREY+CjwveDp4bXBtZXRhPgo8P3hwYWNrZXQgZW5kPSJyIj8+nhxg7wAAB2NJREFUeJztXTFyqzwQ/pJ5FzANfXwEcgS7pLSP4AwNrV2mtNs0THyEUFKGI0RHCH0aOML/F1r5EVkCAZKeHeeb8bwZW5HEslrtftrVu8MvTgiSYgFgA2AFoKyzeKlpNwPwAWAGIAdwSENW9fV/Z3GuV4sgKR4A7MGF3MZTncVHRftX8JfSxhHALg1Zoxvn5oVN2vwGrqUyKgBLAA+t7xpwrVahArBOQ8ZUP960sEmjPy1326QhC1Q//LE80BnIvkX0Af3b1qIGgNAEBqCqs7jX/lmCSpudwalmB0mxB7Ad8adKW+kCQVK8A1hY7HKXhuyg+uHe4iDfQLZwjKAB4JX+3geeLPbVgG+USjgTNqZri+wZuMJDf5NB0Joml8KO+pt0wrYQzkD7yZvFLmcAXnU/uhT2NWADs02SASjBXbs+LF6+IuWqdO6NXBqkvaBvTzkCOLS9I3IXX9FtJjcvX5EIbhrhd9+UsIOk+IC5edvVWXzmVZDglz1ezKL928tXdEhDtrtkM2LVByaNNBU0Uwlawm7A8BvAsmbThrOhz9QNLgqS4hN8KR/rLNZyDoYYMp+8r0GdxSxICgazFzgDeoQdJMUGfDkwALkusmsJeQu7GikIom2QFIcubSPN3YA/fO4pKDIVNl6+okhrRojZegX3d/cAPoOk2JNg2+0W4MTMHu7C3xmAfZAUH0FSfHu4IClmFKl+gr/sBXhQpHXBLGLIamuUwiaNlilEgD/MZ5AUW2q3B/AODz4xIQLwESTFloS8xV8hy9iIeY4cxwTGgVsasuqMGyHN0VGIbTTwTOSMxLLO4pJWZD3g7+ZdhBit6HfDvlgassdvmj0woroGQQPAW5AUM9pg+zyMNs5MpkDrsMEUR0Bi/TQnED8BeZ3Fa/lL8na6TGAF/oLKOosrWvWCYOtStjwN2dl4J2EPXBbXiHWdxd9cOrLpQzTUFMs0ZKX85R0NKg4wfW10/wINuB3+5kEMjCpNcEhDpgx4hM22EYRcOkQsIMMmny3MjhL3pNVjXaRrw1ax6dnc6Gdd/d3DnGb8CVBpt83gp1Nx7+HvRERAcMM7cJfobCNxjFMgQk6BbfOp9eb+wO7moIOwZbmOUKKodQv3e0f7eRmGB2d97ZU5IwDXbJeETQPOC8/rLO5k7og4enQ8H6DF6NF8ltALqKyz+K79ATCHnhPJqT8l7sGXs4ul3AB4NOCFT6izuKmz+AnuBC7MV3tMVmfxI30vC1F1eKCKRCsAT2nI1kbpZ0FSCHbP1jJe1lk8+iVajmYr8OOtzpfYoooX6KFpiYSLwLU57xKygIqIsmE7tRmgpqAHf8e0PcVIyFPw/Pxs3PaMYiXbOofBaUUHhhA+StByHXL0JOMo9oqpc7GFrjPIsb53NcV8tEH9+Mr7cw4Xwp6yImz2d3H0Q5ewx9rKqQezMm5Cs8dC69SPxK+wO2CbZ/kxvE2XsMeaA9u28uJs71h0CXusObDNtfjgbrzAhWavdAelIzE2z9s3m9gLXd7IVOrRSphN0ezYF7fyWL1gBPl0XZwc25jkY53Foz0Ti+eiJXjI7kTTh4Tr4sA3AiehbGqC8oDVFBOKn3QowelerQKQsq3AV+aRGEhVO8HbPGBIha/jFIYKPIVgkIY7TDEA1CkNugR3XYWvShH6K3wdlKbJaMCXcS85RS9eUJeuIPhrMeYG+qTQqs7iecv2N/TRFao24Dkj6gpfD8IWqEBnjkLTpYLUFfy4eU2dxQGN773C11c4fMqPC5LC05BKtDdKr9HpPeyzdJeO9hmkOOm3CX2SDrlEFxcAOEIlb46wnxHVW+E7+WTlSqASrM19ojcjSpyI/HRzUsqBDW3QtjOijCp8n2Cf+L8UNFBrtSkdUGFYha/Su5PD9RXs1nJfCk7BCbl7ggLQ3aAjkINHne0KXxNKo8Rf08xEoKNKZfhp1QensNtGha/AwPhEW+G7Qz+XXUGdQeQLzHB80W5ohW9lEPEOcSo2gDpvpAGwhv5BdvibVjaHf7cxB8+2EuPrcksacPMhnmMIe9ibazIwzWIGaPhsUQwvdVaCs3gH8QCUm7eEHy0XwltL4wuh51Lb5RSK1xDGivbyFUXacmqaqCBhOi/JqrP4ECTFEW5KqkUiozYLlua2FpufK+5aMzfjttYv5LJYx94r5IHzGkIlK0v5FH0ab7hpyO6c3X5mgU2cnJwpzcd2ha9pJTQAVGnI5pd834hV0OoYkmSpPbwYEXmeV/jaxKVptgpBUtToNnXfylNoT1ih30SWacjO5n4zmq1Bn68sjsvqICn+Az9oMLnqw+8litcAchttu4e5qpQacCvsqe6XL/fNNp+t7c+lsI8YH+h0kvCW4bXC1wlo9xeldqZhrRDyow3f2hDeKny93p8t0Ztt+LzGuT0fJzkzaciUcvV6iSIJ9JKS2yvYv35Ju+He9M3wwCkSfIN6xZ35+hTQfEL9gkrwa/iVJvCmXT/gRLiJCl8ZphW+DXjq2fL3P5gwhHQRY9lzUiPS5EoAR5MK3/8BULULMe35GDoAAAAASUVORK5CYII=",Url="",
                CreateAt=DateTime.Now,SlideTypeID=sliderTypes.Single( i => i.Title == "WE PROVIDE")._id},
                new SliderModel{Title = "SOFTWARE TESTING",Description="Provide all kind of testing services including automation tool development, enhancement and execution to assure the quality of our client’s products.",
                Image="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADYAAABICAYAAAC9bQZsAAABS2lUWHRYTUw6Y29tLmFkb2JlLnhtcAAAAAAAPD94cGFja2V0IGJlZ2luPSLvu78iIGlkPSJXNU0wTXBDZWhpSHpyZVN6TlRjemtjOWQiPz4KPHg6eG1wbWV0YSB4bWxuczp4PSJhZG9iZTpuczptZXRhLyIgeDp4bXB0az0iQWRvYmUgWE1QIENvcmUgNS42LWMxNDIgNzkuMTYwOTI0LCAyMDE3LzA3LzEzLTAxOjA2OjM5ICAgICAgICAiPgogPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4KICA8cmRmOkRlc2NyaXB0aW9uIHJkZjphYm91dD0iIi8+CiA8L3JkZjpSREY+CjwveDp4bXBtZXRhPgo8P3hwYWNrZXQgZW5kPSJyIj8+nhxg7wAAAv9JREFUaIHtm7Fum0AYgD87WSJ1gcVSx+QRkqhLR3tkzJIHcMSStR4z1msWFL9ApHZkjNcMlcwj1GvVBaYq2dqBg0IMzh0+MGfdN9knw93H+Q7+/44BLeL64Ri4AsbAqSheA0vgexx4y13ruLu7qywf7HriKlw/PAUeSIW2sQRu4sBbN62rTmzY9IR1uH54Dqx4Xwrxm5U4RitaxURPPQGOwmEO8CSO1YbuHntATSrDEcdqQ5uYmCjq/n4J6Xhais9VjMU5tKCzx65qyhfAWRx4kzjwJsCZKFM5hzI6xaqudgLM4sDLe0l8nlHdc73ssarBHxWlMkRZJHmORhwXv4hpd0r5htoprh/+Vfn9/e/8hr+4HUX5xcpv0K4ffgG+amthSkI6vkq95vqhA/yk2Qy6jdntKJoDHImK2pACOAGck8vr55fV46uoyxF1fW6hvvGPPx9fP3349TwoPCm0SXFMnaO/p95ycUw6ptrGQeOMJ8F02HGFXTEesqfZr2VOtT/d9wUrZhpWzDSsmGm0JVYXlnRGG2IJMIkD74L6SLl1dItlUhFAHHg3pLFS5+gUK0kV2EuvqYhty1VUSomQSGtaTRZZsazhc2BCWW6blGryVBuyYsVxE/FfrpdSIC9Wyq0X5HopBTCQzArVTQwlRCb3G5tSCTBv1sQNtmWcc2TF4B051w+nVE8UUhdFBZk2q8yK2arIxpJPl1KyqN7HNuT6KAVvMsGSZHIT0kmlUynZFRmVMWYUNmwxDStmGlbMNKyYaVgx0zhYMdWH4IQ065SQPgxP2XOkXIeK2Bq4KG5tcP1wTrowX7UqqjNqLnKOxNYkFbH52/0aceAlQq4qdJmLrJZ2dEfQdbtAG+8ObZODnTxUxOr+13Xl2rfDQp7eexfVCHoGLMTYymbFNrYq7YxNDZiGFTMNK2YaVsw0rJhpHLRYL8OOHVkP2dPOmZZZDtnjfqcWWQzFquNs3y3RyOx2FEVHAC+rx+eTy+tXzN+Dn7/bUnqrtg9vIzWg8m2kfym0DD8QJK5SAAAAAElFTkSuQmCC",Url="",
                CreateAt=DateTime.Now,SlideTypeID=sliderTypes.Single( i => i.Title == "WE PROVIDE")._id},

                new SliderModel{Title = "DESKTOP DEVELOPMENT",Description="Our teams understand how to build web applications with insight UX/UI that help to strengthen the client businesses and brand awareness from the bottom-line",
                Image="https://www.titancorpvn.com/assets/images/icons/domains/desktop.png",Url="",
                CreateAt=DateTime.Now,SlideTypeID=sliderTypes.Single( i => i.Title == "DOMAINS & TECHNOLOGIES")._id},
                new SliderModel{Title = "WEB APP DEVELOPMENT",Description="Our teams understand how to build web applications with insight UX/UI that help to strengthen the client businesses and brand awareness from the bottom-line",
                Image="https://www.titancorpvn.com/assets/images/icons/domains/web.png",Url="",
                CreateAt=DateTime.Now,SlideTypeID=sliderTypes.Single( i => i.Title == "DOMAINS & TECHNOLOGIES")._id},
                new SliderModel{Title = "MOBILE DEVELOPMENT",Description="We have expertise in building mobile applications and mobile games on multiple platforms",
                Image="https://www.titancorpvn.com/assets/images/icons/domains/mobile.png",Url="",
                CreateAt=DateTime.Now,SlideTypeID=sliderTypes.Single( i => i.Title == "DOMAINS & TECHNOLOGIES")._id},
                 
                new SliderModel{Title = "CLOUD BASED DEVELOPMENT",Description="We have extensive experience in implementation of specific PaaS and SaaS",
                Image="https://www.titancorpvn.com/assets/images/icons/domains/cloud.png",Url="",
                CreateAt=DateTime.Now,SlideTypeID=sliderTypes.Single( i => i.Title == "DOMAINS & TECHNOLOGIES")._id},
                new SliderModel{Title = "TELECOM & NETWORKING",Description="Our team has strong experience in telecom and network systems that enable us to provide both testing and development services",
                Image="https://www.titancorpvn.com/assets/images/icons/domains/network.png",Url="",
                CreateAt=DateTime.Now,SlideTypeID=sliderTypes.Single( i => i.Title == "DOMAINS & TECHNOLOGIES")._id},
                new SliderModel{Title = "TESTING & QUALITY ASSURANCE",Description="We develop cross-platform standalone and client-server applications which run stability scalable, and also easy to convert to other architects or business models",
                Image="https://www.titancorpvn.com/assets/images/icons/domains/testing.png",Url="",
                CreateAt=DateTime.Now,SlideTypeID=sliderTypes.Single( i => i.Title == "DOMAINS & TECHNOLOGIES")._id},
                 new SliderModel{Title = "BLOCKCHAIN DEVELOPMENT",Description="We have experiences in setting up, configuring, and developing applications based on Block chain technologies: Ethereum, De-centralized, Smart Contract, Cryptocurrency",
                Image="https://www.titancorpvn.com/assets/images/icons/domains/blockchain.png",Url="",
                CreateAt=DateTime.Now,SlideTypeID=sliderTypes.Single( i => i.Title == "DOMAINS & TECHNOLOGIES")._id},
                new SliderModel{Title = "ARTIFICIAL INTELLIGENCE",Description="We have extensive experiences in implementation of specific solutions with AI inside: Core Machine Learning Algorithms, Unsupervised Learning, Data Preparation...",
                Image="https://www.titancorpvn.com/assets/images/icons/domains/ai.png",Url="",
                CreateAt=DateTime.Now,SlideTypeID=sliderTypes.Single( i => i.Title == "DOMAINS & TECHNOLOGIES")._id},
                new SliderModel{Title = "ERP/CRM IMPLEMENTATION",Description="Experienced team to consult and implement ERP and CRM solutions based on Microsoft and Open Source technologies (Dynamics AX/365/NAV, OpenERP(Odoo), SugarCRM, vTiger, and so on) with following services",
                Image="https://www.titancorpvn.com/assets/images/icons/domains/crm.png",Url="",
                CreateAt=DateTime.Now,SlideTypeID=sliderTypes.Single( i => i.Title == "DOMAINS & TECHNOLOGIES")._id},
            
                new SliderModel{
                    Title="SaigonX",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/http___www_saigonx_com_.jpeg",
                    Url="http://www.saigonx.com/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=sliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                new SliderModel{
                    Title="Greenpacket",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/http___www_greenpacket_com_.jpeg",
                    Url="http://www.greenpacket.com/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=sliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                new SliderModel{
                    Title="SSENSE",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/https___www_ssense_com_.jpeg",
                    Url="https://www.ssense.com/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=sliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                new SliderModel{
                    Title="GREENCOPPER",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/https___www_greencopper_com_.jpeg",
                    Url="https://www.greencopper.com/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=sliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                new SliderModel{
                    Title="BGXAI",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/https___www_bgx_ai_.jpeg",
                    Url="https://www.bgx.ai/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=sliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                new SliderModel{
                    Title="wedgenetworks",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/https___www_wedgenetworks_com_.jpeg",
                    Url="https://www.wedgenetworks.com/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=sliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                new SliderModel{
                    Title="DP",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/http___www_digitalperformance_de_.jpeg",
                    Url="http://www.digitalperformance.de/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=sliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                new SliderModel{
                    Title="MinkGeek",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/http___mindgeek_com_.jpeg",
                    Url="http://mindgeek.com/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=sliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                new SliderModel{
                    Title="CollectiveClarity",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/http___www_collectiveclarity_net_.jpeg",
                    Url="http://www.collectiveclarity.net/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=sliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                 new SliderModel{
                    Title="superhippo",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/http___superhippo_com_.jpeg",
                    Url="http://superhippo.com/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=sliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                 new SliderModel{
                    Title="Trafficpartner",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/https___www_etnasoft_com_.jpeg",
                    Url="https://www.trafficpartner.com/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=sliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                 new SliderModel{
                    Title="ewerk",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/https___www_ewerk_com_.jpeg",
                    Url="https://www.ewerk.com/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=sliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                 new SliderModel{
                    Title="ktcc",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/http___www_ktcc_co_jp_.jpeg",
                    Url="http://www.ktcc.co.jp/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=sliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                 new SliderModel{
                    Title="Frogasia",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/https___frogasia_com_.jpeg",
                    Url="https://frogasia.com/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=sliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                 new SliderModel{
                    Title="TVT",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/http___www_tpf_com_au_.jpeg",
                    Url="https://tvt.biz/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=sliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                 new SliderModel{
                    Title="sssmine",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/http___www_sssmine_com_.jpeg",
                    Url="http://www.sssmine.com/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=sliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                 new SliderModel{
                    Title="empiregroup",
                    Image="https://www.titancorpvn.com/uploads/documents/clients/http___www_ecopharma_com_vn_.jpeg",
                    Url="http://empiregroup.vn/",
                    CreateAt=DateTime.Now,
                    SlideTypeID=sliderTypes.Single( i => i.Title == "OUR CLIENTS")._id
                },
                 

                 new SliderModel
                 {
                     Title="DR. TIM PARKER*Chief Technical Officer",
                     Description="We have worked with Titan Technology for the last three years on a complex and evolving software product. We are delighted with the quality of the deliverables, the enthusiasm of the team, and the dedication to our project. We look forward to continuing this excellent relationship in the years to come, and I strongly recommend Titan Technology as a software outsourcing provider.",
                     Image="https://www.titancorpvn.com/uploads/documents/testimonials/Director_of_Application_Development.png",
                     CreateAt=DateTime.Now,
                     SlideTypeID=sliderTypes.Single( i => i.Title == "CUSTOMER TESTIMONIALS")._id,
                 },
                  new SliderModel
                 {
                     Title="THOMAS SANTONJA*Director of Application Development",
                     Description="A professional and dedicated team with a spirit of delivery. Successfully worked along us for delivery of years of features.",
                     Image="https://www.titancorpvn.com/uploads/documents/testimonials/Director_of_Application_Development.png",
                     CreateAt=DateTime.Now,
                     SlideTypeID=sliderTypes.Single( i => i.Title == "CUSTOMER TESTIMONIALS")._id,
                 },
                  new SliderModel
                 {
                     Title="VALERY KHVATOV*VP of Technology",
                     Description="The work of Titan Technology is distinguished by high professionalism and initiative. It is a wonderful combination for a tech company. Our project consisted of building a mobile app for a blockchain platform. The team asked many right questions throughout the development process and in the end the app was even better and more thought out than in our initial view. And to add, we were on budget and schedule. The quality of development is very high as well. Another very positive factor is communication. It is of utmost importance for a remote team. We are delighted to recommend working with Titan Technology, a very mature and responsible company.",
                     Image="https://www.titancorpvn.com/uploads/documents/testimonials/VP_of_Technology.png",
                     CreateAt=DateTime.Now,
                     SlideTypeID=sliderTypes.Single( i => i.Title == "CUSTOMER TESTIMONIALS")._id,
                 },
                  new SliderModel
                 {
                     Title="HONGWEN ZHANG, PH.D*CEO & CTO (co-founder)",
                     Description="Wedge Networks Inc, based in Canada, is a leader in Real-time Threat Prevention for the cloud networks. Our products and services are distributed world-wide. Product quality, reliability, and supportability are critical to our success. That’s why we partnered with Thanh Nguyen and his Titan team. Working as an extended team of Wedge Networks, the Titan team provided world class QA and product support services for us. The team is highly skilled, dependable, and flexible. The successes of our recent product launches are testaments of their significant contributions.",
                     Image="https://www.titancorpvn.com/uploads/documents/testimonials/CEO_&_CTO_(co-founder).png",
                     CreateAt=DateTime.Now,
                     SlideTypeID=sliderTypes.Single( i => i.Title == "CUSTOMER TESTIMONIALS")._id,
                 },
                  new SliderModel
                 {
                     Title="CHRIS HENNIGFELD*Project Manager",
                     Description="We greatly appreciate the reliable and cost-effective team Titan has provided to us to develop and maintain one of our systems with over a thousand internal users for several years.",
                     Image="https://www.titancorpvn.com/uploads/documents/testimonials/Project_Manager.png",
                     CreateAt=DateTime.Now,
                     SlideTypeID=sliderTypes.Single( i => i.Title == "CUSTOMER TESTIMONIALS")._id,
                 },
                  new SliderModel
                 {
                     Title="STEPHEN COLE*CEO",
                     Description="In these challenging times, I wanted to say thank you for the outstanding effort and service we have experienced with Titan.They are professionals who really take customer care to the highest levels.We will definitely be using Titan services for our new upcoming projects. Your Company is exemplary in the world of software development and project management. Our projects have always been on time and within budget at Ai6 and Collective Clarity",
                     Image="https://www.titancorpvn.com/uploads/documents/testimonials/CEO.png",
                     CreateAt=DateTime.Now,
                     SlideTypeID=sliderTypes.Single( i => i.Title == "CUSTOMER TESTIMONIALS")._id,
                 },

                  new SliderModel
                  {
                      Title="",
                      Image="https://www.titancorpvn.com/uploads/documents/recognized/Award_08.png",
                      CreateAt=DateTime.Now,
                      SlideTypeID=sliderTypes.Single( i => i.Title == "As Recognized By")._id,
                      Url="https://www.certipedia.com/quality_marks/9000008850?locale=en"
                  },
                  new SliderModel
                  {
                      Title="",
                      Image="https://www.titancorpvn.com/uploads/documents/recognized/Award_01.png",
                      CreateAt=DateTime.Now,
                      SlideTypeID=sliderTypes.Single( i => i.Title == "CUSTOMER TESTIMONIALS")._id,
                      Url="https://www.goodfirms.co/company/titan-technology-corporation/focus"
                  },
                  new SliderModel
                  {
                      Title="",
                      Image="https://www.titancorpvn.com/uploads/documents/recognized/Award_03.png",
                      CreateAt=DateTime.Now,
                      SlideTypeID=sliderTypes.Single( i => i.Title == "CUSTOMER TESTIMONIALS")._id,
                      Url="http://vinasa.org.vn/Default.aspx?sname=vinasa&sid=4&pageid=3074&catid=4199&catname=gioi-thieu"
                  },
                  new SliderModel
                  {
                      Title="",
                      Image="https://www.titancorpvn.com/uploads/documents/recognized/Award_04.png",
                      CreateAt=DateTime.Now,
                      SlideTypeID=sliderTypes.Single( i => i.Title == "CUSTOMER TESTIMONIALS")._id,
                      Url="http://vnito2015.vnito.org/award/"
                  },
                  new SliderModel
                  {
                      Title="",
                      Image="https://www.titancorpvn.com/uploads/documents/recognized/Award_05.png",
                      CreateAt=DateTime.Now,
                      SlideTypeID=sliderTypes.Single( i => i.Title == "CUSTOMER TESTIMONIALS")._id,
                      Url="http://www.phunhuan.hochiminhcity.gov.vn/Pages/default.aspx"
                  },
                  new SliderModel
                  {
                      Title="",
                      Image="https://www.titancorpvn.com/uploads/documents/recognized/Award_02.png",
                      CreateAt=DateTime.Now,
                      SlideTypeID=sliderTypes.Single( i => i.Title == "CUSTOMER TESTIMONIALS")._id,
                      Url="http://vjc.org.vn/japanictday/vi/homepagevn/"
                  },
                  new SliderModel
                  {
                      Title="",
                      Image="https://www.titancorpvn.com/uploads/documents/recognized/Award_06.png",
                      CreateAt=DateTime.Now,
                      SlideTypeID=sliderTypes.Single( i => i.Title == "CUSTOMER TESTIMONIALS")._id,
                      Url="https://hca.org.vn/post/13266"
                  },
                  new SliderModel
                  {
                      Title="",
                      Image="https://www.titancorpvn.com/uploads/documents/recognized/Award_07.png",
                      CreateAt=DateTime.Now,
                      SlideTypeID=sliderTypes.Single( i => i.Title == "CUSTOMER TESTIMONIALS")._id,
                      Url="https://www.jetro.go.jp/en/"
                  },

            };

            foreach(var slider in sliders)
            {
                context.Sliders.Add(slider);
            }   
            context.SaveChanges();

            var posts = new PostModel[]
            {
                new PostModel{
                    Title="YEAR-END PARTY!!! 2022",
                    ShortDesc="We at Titan recently celebrated the end of an eventful year with our YEAR END PARTY 2022! After a year of dedicated work, Titan have experie.Despite the challenges posed by the ongoing pandemic, economic instability, and other difficulties, we at Titan are grateful to have had your support. Together, we have managed to navigate through a difficult year. We also took this occasion to acknowledge and celebrate the outstanding contributions of our excellent employees during the past year. ",
                    FullDesc="Despite the challenges posed by the ongoing pandemic, economic instability, and other difficulties, we at Titan are grateful to have had your support. Together, we have managed to navigate through a difficult year. We also took this occasion to acknowledge and celebrate the outstanding contributions of our excellent employees during the past year.\r\n\r\nTitan big family had moments of full play and experienced a very special and funny year-end party together in solidarity. All promise a new year with lots of luck for everyone.\r\n\r\nAs we look forward to 2023, we at Titan remain committed to making further efforts to improve and grow as a company. We would like to extend our sincere gratitude for your continued support of Titan.",
                    Author="Admin",
                    Image="https://www.titancorpvn.com/uploads/images/news/YEP_2022_Activity_122022_0.jpeg",
                    PostTypeID=postTypes.Single(i => i.Title == "NEWS & EVENTS")._id,
                    Url="https://www.titancorpvn.com/news/YEP_2022_Activity_122022",
                    CreateAt=DateTime.Now,
                },
                new PostModel{
                    Title="WARM WINTER CHARITY 2022",
                    ShortDesc="Titan organized a charity event named “Warm Winter” that gave away 288 packages of gift including uniforms, cold weather clothing, and schoo…",
                    FullDesc="Residing in a tropical country, we sometimes take for granted the life-saving necessities of staying warm. The truth is that there are areas within Vietnam where residents, especially underprivileged children, are affected by cold and extreme weather events. Acknowledging the harsh conditions faced by children living in remote and mountainous areas, Titan organized a charity event named “Warm Winter” that gave away 288 packages of gift including uniforms, cold weather clothing, and school stationary sets to the students at Da Nhinh Elementary School in Dam Rong, Lam Dong in October 2022. Our donation before the wintertime was more than just making the little kids comfortable. Titan members and the Company itself wanted to give the gift of hope that delighted the kids and inspired them to continue their education.",
                    Author="Admin",
                    Image="https://www.titancorpvn.com/uploads/images/news/Warm_Winter_Charity_2022_0.jpeg",
                    PostTypeID=postTypes.Single(i => i.Title == "NEWS & EVENTS")._id,
                    Url="https://www.titancorpvn.com/news/Warm_Winter_Charity_2022",
                    CreateAt=DateTime.Now,
                },
                new PostModel{
                    Title="2020 TAX COMPLIANCE AWARDS",
                    ShortDesc="Titan Technology Corporation won the “2020 Tax Compliance Excellence Award” and the “2020 Taxation Responsibility Fulfillment Excellence Awa… ...",
                    FullDesc="Acknowledging that our taxes meaningfully fund essential public services for the country and represent an investment in raising the Vietnamese people's living standards, Titan has always actively contributed to government's revenues from taxation. For our accountable behavior, Titan Technology Corporation won the “2020 Tax Compliance Excellence Award” given by the Ho Chi Minh City Tax Department and the “2020 Taxation Responsibility Fulfillment Excellence Award” given by the People's Committee of Tan Binh District in April 2022. The awards were bestowed upon 69 out of 41,623 enterprises operating in Tan Binh District.",
                    Author="Admin",
                    Image="https://www.titancorpvn.com/uploads/images/news/20220607_2020_Tax_Compliance_Awards_0.jpeg",
                    PostTypeID=postTypes.Single(i => i.Title == "NEWS & EVENTS")._id,
                    Url="https://www.titancorpvn.com/news/20220607_2020_Tax_Compliance_Awards",
                    CreateAt=DateTime.Now,
                },

                new PostModel{
                Title="5 TECH TRENDS IN HEALTHCARE AND MEDICAL APP DEVELOPMENT",
                ShortDesc="There are many medical apps on the market; every day there are more and more healthcare startups. If you decide to create a medical app, you need to think outside the box and you need to....",
                FullDesc="\r\nThere are many medical apps on the market; every day there are more and more healthcare startups. If you decide to create a medical app, you need to think outside the box and you need to create something new and extremely innovative that will combine all the best technologies in one app.\r\n\r\nNevertheless, what makes the healthcare application unique? Is it the UI that is easy to use? Auto-fill structure? “Time to take your pills” notifications? Home delivery from pharmacy options? Or maybe all mentioned above and more? In this article, let’s take a look at technological trends of healthcare and medical app development in the coming year.\r\n\r\n1. Mobile Health.\r\n\r\nWhat is it? According to the World Health Organization, mHealth (mobile health) is medical and public health practice supported by mobile devices, such as mobile phones, patient monitoring devices, personal digital assistants (PDAs), and other wireless devices. mHealth involves the use and capitalization on a mobile phone’s core utility of voice and short messaging service (SMS) as well as more complex functionalities and applications including general packet radio service (GPRS), third and fourth generation mobile telecommunications (3G and 4G systems), a global positioning system (GPS), and Bluetooth technology.\r\n\r\nThe future healthcare trends in 2021 are directly related to mHealth. Such mHealth applications provide 24-hour online chat platforms and medical video consultation apps. In addition to creating the above-mentioned online support network, they also allow requesting professional doctors at home based on patients’ symptoms.\r\n\r\n2. Machine Learning and Artificial Intelligence.\r\n\r\nWe know that future healthcare trends depend on machine learning and deep learning. AI is also a technology that takes healthcare trends to a new level. When the world faced a pandemic, artificial intelligence helped us. For example, scientists were using AI algorithms to discover the Covid-19 vaccine. In the next few years, we will easily manage such epidemics through complete control and artificial strategies. The use of AI and ML in healthcare has exceeded our expectations.\r\n\r\nMachine Learning in healthcare can detect diseases more accurately at an earlier stage, thereby helping to reduce the number of readmissions in hospitals. This technology has also gone a long way in discovering and developing new drugs with great potential to help patients with complex diseases.\r\n\r\n3. Digital Pharmacy.\r\n\r\nIt’s the fusion of the digital revolution and pharmacy. Buying healthcare products in online pharmacies and receiving them at your door is one of the facilities proposed by the technological revolution in the healthcare industry. This is a new and exciting concept in healthcare application development.\r\n\r\nDigital pharmacies not just provide you with your medicine, but also sort your pills by date and time, deliver them to you every month, including any other pharmacy items. Besides, digital pharmacies monitor and manage your refills together with your doctor so that you always have the medicines you need.\r\n\r\nBehind the scenes, they also work directly with your doctor and insurance company to save you time and trouble. And the most important that with digital pharmacies everything is in one place. They organize all your medicines, bills, and prescription details for easy use. One of the great solutions that can be an example in this area is PillPack by Amazon Pharmacy.\r\n\r\n4. IoMT in healthcare and medical apps development.\r\n\r\nWhat is it? The Internet of Medical Things (IoMT) envisions a network of medical equipment and people that use wireless communication to exchange medical data.\r\n\r\nVarious devices and mobile applications of the Internet of Medical Things (IoMT) play a vital role in tracking and preventing chronic diseases of many patients and their doctors. By combining the development of the Internet of Things with telemedicine and telemedicine technology, a new Internet of Medical Things (IoMT) has emerged. This method involves the use of many wearable devices, including ECG and EKG monitors. With modern full-cycle software product development services, many other common medical measurements can also be taken, such as skin temperature, glucose level, and blood pressure readings.\r\n\r\n5. Augmented, Virtual, and Mixed Reality.\r\n\r\nVR and AR in healthcare are important technologies that have great potential to improve the quality of telemedicine during the COVID-19 pandemic. From enhancing patient and provider access to helping medical students with program simulation education, this technology is turning science fiction into reality. These technologies can bring contemporary benefits to surgeons and medical students. VR can help doctors use extended reality solutions to train themselves.\r\n\r\nTo sum up, we can write only 14 letters, but they will include over 5 technological trends in healthcare app development in 2021: ML, AI, VR, AR, MR, IoMT.\r\n\r\n— 0o0 —\r\n\r\nAs one of leading software development outsourcing companies in Vietnam, Titan Technology always use cutting-edge technologies to deliver all the best outcomes to our partners in over the world along with providing above good environments for any developer will need to explore themselves in this market.\r\n\r\nIn case you just grew your interest in working with Titan Technology, we are opening for many positions that suit with all your potential.\r\nFor your own feeling about Titan, feel free to check our website and submit your CV to us if you already have interest to become a Titaner :\r\n\r\nGet inspired with Titan’s environment here: https://www.titancorpvn.com\r\nReach to our incredible Recruitment Team: recruitment@titancorpvn.com\r\nSource: By Romana Kuts",
                Author="Admin",
                Image="https://blog.titancorpvn.com/wp-content/uploads/2021/04/5-Tech-Trends-in-Healthcare-and-Medical-App-Development-01.jpg",
                PostTypeID=postTypes.Single(i => i.Title == "BLOGS")._id,
                Url="https://blog.titancorpvn.com/5-tech-trends-in-healthcare-and-medical-app-development/",
                CreateAt=DateTime.Now,
                },
                 new PostModel{
                Title="A DEVELOPER’S TALE OF DEADLINES AND FANTASY TIME ESTIMATES",
                ShortDesc="You were asked to write a program, and during the discovery phase of the discussions, you were asked how long it was going to take",
                FullDesc="You were asked to write a program, and during the discovery phase of the discussions, you were asked how long it was going to take. The spotlight was on you and everyone turned to face you. On their faces you could see the real question they were asking… How long are you going to set us behind our actual target? Cause let’s face it, that is what they really want to know. How long do they have to wait before they can use and advertise that new feature to the market?\r\n\r\nYou start to feel the pressure that everyone is suddenly counting on you. Maybe you are the new developer on the team, the last thing you want to do is to let everyone down. Without any real research or details, you make a quick mental calculation and ballpark a time frame, based on what you know so far.\r\n\r\n“It could take me about 6 weeks, give or take”, you say, all the while hoping they note you said “could” to imply speculation and not a fixed possibility.\r\n\r\n“Okay! If you could bring that down to 4 weeks that would be fantastic yeah?” is what you hear.\r\n\r\nEveryone is excited. Your manager is brimming as they note the time frame down and base plans around that schedule. They are expecting a working program in 4 weeks. You look around at everyone making plans around that time estimate, and that’s when it sets in, a nagging uneasiness at the back of your mind; you didn’t factor all the things that could go wrong and will go wrong. A nagging thought starts to settle in, there is something you forgot to account for. Anyway, what’s done is done, you say to yourself. You decide you will do the best you can with the time you have and hope everything goes as close to the plan as possible. Let the journey begin.\r\n\r\n\r\nDuring week 1, you finally receive the design documentation and program specifications. As you read the specifications, you notice some additional bullet points that were not mentioned in the initial discussion. You confirm with your manager if this is real or enhancement requests after the initial release. To your worst expectation, it is real and part of the initial requirements. You should have known not everything was mentioned in the discovery phase. You compare what you thought you were building with what you shall be building with the new design specifications. Somewhere by the end of the week 2, you have managed to jot down a few options on what possible approaches you could take to tackle the problem. You have mentally weighed their observable pros and cons (yes, observable because sometimes appearances are deceiving) and are close to selecting a single approach. You scribble a quick flow chart and theorize a couple of tests that your program must pass and those it must fail, basically define the boundaries of your testing conditions.\r\n\r\nBy the beginning of week 3, you have a clear direction to follow, you are aware you have only 2 weeks left but you feel confident enough since your action plan is already set, all you must do is build the parts. And so, you begin. Everything is going well and midway to week 3, you have begun testing a few of the components you have already built as you integrate them into the main program. Sometime during the middle of the third week, at the start of the fourth day, a critical bug gets reported on a different project and it requires your immediate action. You question whether it is critical or just a slight exaggeration. You get confirmation from your manager confirming it is critical if you could get right on it. You really do not have time for this but oh well you must look at it. What is the worst that could happen you wonder?  Naturally, you take on the task and sideline your current project. Suddenly, your co-workers are signing off and to your shock, it’s already the end of the day. You spent the entire day working on the bug, and to your dismay it’s the end of the day, you haven’t fixed the bug nor made any progress on the project. You start to feel just a little nervous. Next day, you are still working on fixing the bug, this time more voraciously, you have to get this done because all this time is costing your current project. Luckily by the end of the day, you have a working bug fix. You aren’t too happy with it because you haven’t had time to thoroughly test it, but then again you are way off your schedule, it’s already midday.\r\n\r\n\r\nBy week 4, you can finally get back to your project. You start to get a feeling of urgency creeping up on you. This is the deadline week. You psych yourself up, if you focus on this and only this, you could pull it off by a hair. Just as you start working on the project, you get called into a sync meeting, everyone is giving updates and all other parties want updates so they can revise the time frame. You are shocked; you completely forgot about this meeting. That takes off another 40 minutes at least from your time. You can feel the need for an extension; however, you haven’t figured out how to ask for one without seeming like you are just asking for the sake. You quickly put together a few slides with your flow chart showing what you have done so far and what you need to do. If you are going to get an extension, you will need everyone invested in understanding why it is important you get that extension.\r\n\r\nDuring the meeting you discuss what you managed to get done, the problems you encountered and how you intend to fix them, for those you still haven’t worked on, you discuss the strategies you intend to take when implementing them. Finally, with all the cards on the table, you make a request for an additional couple of days to complete your part in the project. Your manager eyes you curiously, then says okay, you get your extra week. You remain levelheaded, but inside you jump in relief. You didn’t need a whole week, but with a whole extra week, you could actually do more thorough testing. As you work to complete the project, you make a mental note to next time, not give time estimates, or better yet, ask for time to think about how long you think it will take. However, deep down, you know you will be doing this fantasy time estimate all over again on the next project, because for some reason, that is just how it goes.\r\n\r\n1. So why is this all-just fantasy?\r\na. Software development is subjective to a lot of the roadblocks encountered in any creative process.\r\n\r\nI have come to realize that writing software is a lot more of a creative process than people realize. The programming languages we choose, frameworks, libraries etc. are all technical, but how we implement them, integrate them, or manipulate them to solve a problem is inherently a creative process at the mercy of the person tasked with solving the problem. It is the reason multiple solutions can exist for the same problem. Everyone can have the same tools, but the masterpiece each produces is different and subjective to their creative process.\r\n\r\nWe go through the same motions as any creative writing. We have times when the plan is clear and times when we stare at our editor not knowing what to start with or what to write next. We design how everything is connected and where they are connected and keep revising these decisions as requirements change. We consider each user individually and at the same time we consider the collective users and how we might meet their needs. We write a bunch of code one day, then delete all of it another day because it just doesn’t sit right. We wake up some days confident with what we have done so far and some days we second guess every decision we have made thus far. This goes on until we have a final product. It’s a whirlwind of ups and downs.\r\n\r\nTime estimates in a creative process are akin to a sort of fantasy time. We hope it will take X amount of time, but at the end of the day, we truly do not know, it is just a hope based on similar situations or experiences.\r\n\r\nb. There are no real one size fits all solution.\r\nThe assumption behind time estimates is that problems that appear similar and are of similar complexity should by extension take a similar amount of time to solve. If you really think about it, if it was the same problem, all one would need to do is plug the same solution. Similar is not the same. Therefore however “similar” problems appear, they are inherently not the same and therefore require modifications to make them work. The time associated with these modifications is not always known or constant as each problem is a new venture.\r\n\r\nc. You probably have a lot of tasks you are working on.\r\n\r\nIdeally, when you initially estimated the time it would take, you did not factor in external environments such as how the other projects you were working on would still need your attention.  When asked for your time estimate, you probably isolated that project from all the rest. What you really meant was “Without other commitments and in a perfectly isolated environment, it could take me X amount of time if all other factors are held constant”. By factors you meant, if program specifications do not change, if no additional requests are made and if you do not have to share your time with other projects.\r\n\r\nd. Changing program specifications midway does not affect time in any predictable fashion.\r\nThere is an assumption that removing specifications directly means the software can be completed in less time. While this might be true in certain scenarios, I have yet to discover this as truth. Ironically, what I have experienced is adding or removing specifications midway just affects time estimates in the same way; they no longer apply. It does not mean you will finish the project faster. All it means is you must revise your software and consider how this change will affect the work you have already done thus far. It also means you must consider what you would need to add or remove to meet the new program requirements.\r\n\r\ne. Things will go wrong and sometimes there is no quantifiable time taken to fix them.\r\nSometime during the process, some unforeseen problems may occur, and it is entirely possible, it could take days or weeks to figure out how to solve those problems. Problems may come from your computer, your chosen language, framework, dev environment, latest updates released by one of your dependencies, inability to integrate third-party tools properly etc. It could even come from the solution you chose to implement. Turns out, maybe the testing phase revealed it is not as efficient as initially estimated and is therefore not optimal and now you are back to the drawing board 9 days before the deadline. Factoring for potential errors is difficult as you cannot foretell what problems may occur and how long it will take to solve them.\r\n\r\nf. There is a lot of interdependence within the system.\r\nWhen collaborating to write software in a team, it is common to split the tasks between team members. Ideally, each of the tasks can be completed independently, however, in some cases, they could depend on each other. If one-part lags, it drags the dependent part with it. Typically, to curb this, it is ideal to simulate the input and write one’s section accordingly as you wait for the actual input. Sometimes, this approach works but, in some cases, it may be harder to do. For example, it can be difficult to simulate images that require subsequent image processing to remove defects or unwanted artifacts without having an idea what the defects could be. Therefore, a delay in completing the first part that supplies input to a second part, may delay the second part as well.\r\n\r\n\r\nIn a team, collaboration is at the heart of writing chunks of software. You may be struggling to fix something and subsequently affect your teammate’s ability to work on their part, because it relies on you finishing yours. Thereby not only affecting your time schedule but theirs too putting pressure on both of you. Therefore, having proper estimates that account for delays on your side, could help your teammates estimate how they are also affected and can adjust the schedule appropriately without allowing the stress to beat the deadline fall on them.\r\n\r\ng. You aren’t good at estimation.\r\nIt’s easy when others place the time estimate on you and sure you can blame them, but sometimes, even your own time estimations just aren’t good enough. You thought it would take an hour, it took 2 hours. You thought it would take 2 weeks, you were given 1 week, you missed the deadline and were given an extra week and you still missed the deadline. Therefore, your initial estimation was still wrong. What are we without idealistic human optimism? It is easy to think of oneself as being able to power through the mental drain writing software takes, however, often, mental drain comes coupled with physical drain and the time taken to rest and power up in between is often overlooked. Small things often add up to big things. Taking time to rest, brainstorm occasionally, are tasks that are difficult to accurately quantify but do matter and can take up quite some time. They may seem trivial when ballparking an overall time estimate, but they significantly affect the time taken to write software.\r\n\r\n2. So why do we still need real time estimates?\r\nIf time is all a fantasy, why do we still need and rely on it? As much as software development is a creative process, it’s aim is to have real-time use.\r\n\r\na. Your users have a real-time use for it.\r\nImagine if you sat down at a restaurant for lunch and planned to order the special. However, when you asked the waiter how long it would take, they told you they had no clue, it would be ready when it was ready. I am pretty sure you would order something else. How do you plan the rest of your day around a lunch that has an unknown time factor in it? I mean you could gamble and order it and best-case scenario you get your lunch in 15 to 30 minutes or find yourself hours later still waiting for lunch.\r\n\r\n\r\nNeed has a time factor to it. Something needed in the next 3 months does not apply if it arrives in 6 months. Therefore, you may have to plan what is feasible around your user’s needs. If you are organizing a marathon and need an app made to track runner’s location, pace, vitals, speed and direct them along the proper route, there is absolutely no use in getting the app long after the marathon is over. It no longer solves the problem. Giving a time estimate to how much time would be needed to create the app can give stakeholders proper time to plan around the deadline or even start the project earlier than intended to meet the user’s needs. In the marathon scenario, if it is too late to create an app to meet that marathon, maybe for the next marathon, the project can be started well before the marathon’s date with the time estimated.\r\n\r\nb. Deadlines can help one stay focused.\r\nI tend to procrastinate sometimes and when it comes to my side projects, they can suffer especially when my interest has faltered, or when I have become deeply obsessed with a different project, and there is no fixed deadline. Time estimates help me stay focused on a specific task for a certain amount of time. Even though I may procrastinate within the set time frame, at the back of my mind, I am aware there is a project that needs to be completed and I will carve out time to get it done.\r\n\r\nc. Time estimates do aid in overall planning.\r\nI don’t think people ask for time estimates because they enjoy putting people under pressure, if they do, you should probably reconsider your work environment. Time estimates help others plan their part of the project around a given time frame. A lot of software is integrated or built to work hand in hand. You can’t launch a product if part of the product is missing a vital area. Since the entire system is the sum of its parts, how long it will take is affected by the time estimates of each part. With near approximate time estimates, the project manager can decide which parts can be created in parallel, which parts can only start once a different section is complete and overall, how this affects when they can complete the project.\r\n\r\nWe tend to understand the reason for time estimates and why we sometimes fall short of how long we think something will take. So, the next step would be to re-evaluate how we estimate software design.\r\n\r\n3. So how can I get better at estimating?\r\nI still catch my breath when someone asks me, “How long will this take?” Why does this question cause me so much anxiety? Well, because at the back of my mind, I am aware of all the bits that go into time-estimates as well as all those we typically overlook. However, with time I have come up with a bunch of steps I take to break down how long I think a project will need. I haven’t nailed it down to the second, however, with time I have gotten better at giving better approximations on how long I think I will take on a project.\r\n\r\na. Give a rough estimate and ask for time to break down the problem and come back with a better estimate.\r\n\r\nNowadays, I give an initial rough estimation based on the mental gymnastics I can perform at that time; however, I also ask for some time to come up with a better time estimate outside of the meeting environment. Doing this often allows me to sit with the scope of the project, break it down into chunks and identify what I think each chunk will take. Once that is done, to each chunk I add various miscellaneous time estimates, “Exploratory time”, “Bug fix time” and “Pause time”. These are not industry terms just personal terms.\r\n\r\n“Exploratory time” is generally the time I estimate I will take to consider my options in determining how to implement that chunk. Great thing about writing software to solve problems is there can be multiple solutions to one problem. Ironically, this can also sometimes be a problem. Too many options can lead to analysis paralysis when trying to determine which approach one should use given their problem. Personally, when choosing options, I do take time to consider how each option could solve the problem, their flexibility, advantages, disadvantages, future maintainability, and general interdependence. I also consider, if I choose to change my approach later, what will be the cost to switch to a different solution and how difficult will that be? I have found that adding an exploratory time also allows me to research without feeling like I am costing the overall time, because I accounted for time to explore my options in depth.\r\n\r\n“Bug fix time”, is generally the time I estimate it will take me to find and fix bugs in a particular chunk. When writing software that is like something you have implemented previously, this time estimate might not be necessary, however, for newer programs, it might just be necessary. I find having this time is a safety net for when I get stuck on a bug that I am unsure how to solve. It isn’t easy to estimate how long it will take to fix a bug but estimating there will be no bugs at all is worse. When bugs do pop up, urgency and subsequently stress set in because you had not budgeted for time to fix bugs. This has happened to me in the past, and I hated it. However, expecting things to go wrong and having time set aside to solve them can leave you feeling calm and still on time in the grand scheme of things.\r\n\r\n“Pause time” is generally a nice way of saying break time. Time to step away from the software, take a break and refresh. Each chunk gets its own pause time because not all chunks are the same, thus their mental and physical drain can be different. The break I need after fighting with css may not be the same break I need after writing tests.\r\n\r\nGenerally, consider your habits when writing programs, how long did those small things you overlook take? Find a way to term them and add them to your general time estimates.\r\n\r\nb. Estimate sections you are familiar with differently from those you are unfamiliar with.\r\n\r\nFamiliar things are easier to estimate because we have done them 10, 100 or even 1000 times. We know the general flow and how long it takes us to work on them. However, even things that seem similar are not always entirely similar in every aspect. Nonetheless, even minor variations are easy to handle because they only deviate so slightly. Therefore, their estimates can be close enough to problems previously encountered.\r\n\r\nThings we are unfamiliar with are harder to estimate because we have never done them before. Maybe we have heard of them and know the general approach, but we have never actually sat down and implemented them. So how do we estimate something we have never done before? One approach would be to use estimates based on other’s experience. When we do not know how long something will take, we could either make a speculative guess, or rely on those with experience on the matter and ballpark our estimates based on theirs. It is not ideal, but it is better than magically producing a number. However, there are a lot of unknowns that come with using other people’s estimates on how long a task should take. For one, time estimates on known matters are subjective and can be influenced by experience. Someone who has designed and written hundreds of application code that queries databases may take only X amount of time to implement something similar when compared with someone who has never done it before. Knowledge in a certain domain also influences how long one takes to write code in that domain. We are all different.\r\n\r\nPersonally, when it comes to estimating the time, I will take to work on something I have never done before, I tend to take a senior’s time estimate then double it. By doubling it, I can have time to implement it twice in theory. Once to get it done, and I use the extra time to review my understanding of the task, setting myself up for the next time I may have to implement a similar task.\r\n\r\nc. Remember to take your personal habits into account.\r\nPeople are different and have different habits. How we tackle problems, how we brainstorm and eventually how we assess, and handle situations is also different. Some people prefer to tackle the same problem for hours on end then take breaks, while others prefer to concentrate for a couple of minutes with short breaks in between. Some would prefer to work on mentally tasking projects during the evening while others prefer working on such tasks in the morning hours of the day. Some people can’t work on an empty stomach while others can’t work on a full stomach. Nonetheless, whatever your preference is, consider how your habits affect your performance and take them into account when estimating. Will you need more breaks in between or not? Do you need to devote ample time to doing research or not?\r\n\r\nd. Keep your team informed, and if revisions are necessary, consult them.\r\n\r\nAll in all, whatever happens, always keep your team in the know. I do realize this is not a direct way of getting better at giving time estimates, but constantly communicating with your team about your efforts and where you are in the timeline can allow you and your team to revise the timeline and everyone that is affected is informed well ahead of time. Remember writing software and launching a product is a team effort, you may not think they are affected by revisions to your timeline, but they probably are.\r\n\r\ne. Lastly, learn from your own estimations.\r\nEvery time you work on something, note how long you thought it would take, and how long it took. Then compare how far off your estimation was. Were there outside factors that caused this value to deviate exceptionally, and if there were what were those factors. With time and learning from your own experience, you should get better at estimating.\r\n\r\nBy having close to accurate time estimates, you will realize you may finish projects earlier than expected if everything goes right. When things do go wrong, you still have some time to fix them without affecting the overall project deadline.\r\n\r\n— 0o0 —\r\n\r\nAs one of leading software development outsourcing companies in Vietnam, Titan Technology always use cutting-edge technologies to deliver all the best outcomes to our partners in over the world along with providing above good environments for any developer will need to explore themselves in this market.\r\n\r\nIn case you just grew your interest in working with Titan Technology, we are opening for many positions that suit with all your potential.\r\nFor your own feeling about Titan, feel free to check our website and submit your CV to us if you already have interest to become a Titaner :\r\n\r\nGet inspired with Titan’s environment here: https://www.titancorpvn.com\r\nReach to our incredible Recruitment Team: recruitment@titancorpvn.com\r\nSource: By Louiz Loet",
                Author="Admin",
                Image="https://blog.titancorpvn.com/wp-content/uploads/2021/04/A-developers-tale-of-deadlines-and-fantasy-time-estimates-01.jpg",
                PostTypeID=postTypes.Single(i => i.Title == "BLOGS")._id,
                Url="https://blog.titancorpvn.com/a-developers-tale-of-deadlines-and-fantasy-time-estimates/",
                CreateAt=DateTime.Now,
                },
                  new PostModel{
                Title="A PRACTICAL GUIDE TO BETTER CODE REVIEWS",
                ShortDesc="A CODE REVIEW is a part of the development process in which a developer and their colleagues work together and look for bugs within some code",
                FullDesc="A CODE REVIEW is a part of the development process in which a developer and their colleagues work together and look for bugs within some code that may be ready for release. At such a moment, you can be either the code developer or one of the reviewers.\r\n\r\nOn one side of this process, you might not be sure of what you are looking for. On the other side, when submitting a code review, you might not know what to expect. This lack of empathy and wrong expectations between the two sides can trigger unfortunate situations and rush the process until it ends in an unpleasant experience for both sides.\r\n\r\nCode reviews can be a powerful means to achieve higher quality code, establish best practices, and to spread experience and knowledge. It also lets developers learn from their peers, practice mentorship, and engage in open dialog and discussion about what they build.\r\n\r\nHowever, when done wrong, code reviews can come to nothing or harm the interpersonal relationships of a team. Therefore, it is important to pay attention to the human aspects of code reviews. To be most successful, code reviews require a certain mindset and phrasing.\r\n\r\nHere’s how I have this organized:\r\n\r\nMy Code Review Experiences.\r\nGeneral Code Review Guidelines.\r\nCode Reviews as a developer.\r\nCode Reviews as a reviewer.\r\nWho Should Review?\r\nPositive Code Review Culture\r\nThe Subconscious Implications of a Code Review\r\n1. End-User Code Review (no process)\r\nWhen I started working as a developer, I remember having no code review process. In fact, the only review I got was a notification that some bit of code was not working correctly when a customer reported the issue. I learned very quickly that console.log did some nasty things with earlier versions of IE.\r\n\r\n2. Everyone Stare At Me (weekly target practice)\r\n\r\nFrom this, our team began an informal weekly process where we took some code and reviewed it while crammed into my boss’s office. What a painful process … having to explain design decisions on the spot in front of the entire development team; or even worse, trying to come up with intelligent questions about code in a language I had little familiarity with.\r\n\r\n3. Everyone Reviews (learning to accept criticism)\r\nThe next team I worked with had a review process that was embedded into the commit and push toward the production process. Everyone on the team was included in the process, by default. The tooling in Gerrit actually made the process much simpler and quite intuitive; in fact, we were able to get a group put into Gerrit that allowed us to simplify the process of adding people as reviewers.\r\n\r\nThe first few times my code was pushed, the code reviews were painful (not having a clue what to expect) and I firmly believe I was learning almost as much about code reviews as I was generating code for the project itself.\r\n\r\n4. How Is One Individual So Good At This?\r\nWe had an exceptional reviewer on this team that not only came up with exceptional insights into the code, he managed this in a way that made it feel painless. Because of this interaction, I have taken the time to investigate how I can duplicate this type of effort (the painless part … the insights I know will come with time).\r\n\r\n5. Code Review Guidelines\r\n\r\nThese guidelines stem from what a code review should accomplish. It is impossible to lay out guidelines that can be applied to every situation. Keeping these goals in mind will help achieve “the spirit” of code reviews even when a situation comes about that these guidelines don’t cover.\r\n\r\nCode reviews should:\r\n\r\nVerify that the code is a correct and effective solution for the requirements at hand.\r\nEnsure that the code is maintainable.\r\nIncrease shared knowledge of the codebase.\r\nSharpen the skill of the team through regular feedback.\r\nNot be an onerous overhead on developer time.\r\n6. As a Developer\r\nFor you, as the developer (or “author”, “submitter”), it is important to have an open and humble mindset about the feedback you will receive.\r\n\r\nAnyone can do a code review, and everyone must receive a code review, no matter the seniority level. Receive any feedback gratefully as an opportunity to learn and to share knowledge. Look at any feedback as an open discussion rather than a defensive reaction.\r\n\r\nWe are human. And humans make mistakes. This is completely normal. As long as the software is written by people, it will contain mistakes.\r\n\r\nThis does not mean that you should write code carelessly or stop writing tests. But this mindset will take away the fear of mistakes and create an atmosphere where making mistakes is accepted. This, in turn, is important for criticism during a code review to be accepted.\r\n\r\n7. Exchange of Experience\r\nDuring a code review, the developer and reviewer are exchanging best practices, experiences, tips, and tricks.\r\n\r\n\r\nThe developer and the reviewer are not only talking about the code they are exchanging best practices and experiences. Code reviews are a great means to establish and internalize good coding styles and best practices. And the exchange works in both directions. So consider code reviews as a valuable source of knowledge and an opportunity to learn.\r\n\r\n8. As a Reviewer\r\nLocating code to improve is a small part of a successful code review. Just as important is to communicate that feedback in a healthy way by showing empathy towards your colleagues.\r\n\r\nAs a reviewer, it is extremely important to pay attention to the specific language of the feedback. The phrasing is crucial for your feedback to be accepted.\r\n\r\nRight: “It’s hard for me to see what this code is doing.”\r\nWrong: “You are writing cryptic code.”\r\n\r\nAlways formulate the feedback from a personal point of view by expressing personal thoughts, feelings, and impressions. It is difficult for the code developer to argue against personal feelings since they are subjective.\r\n\r\nBefore submitting a comment, remember to put yourself in the other person’s shoes. It is too easy to be misunderstood, so review the comment, always staying respectful … speaking well to others is never a bad decision.\r\n\r\n9. Take the Developer Out of the Feedback\r\nTake the developer out of the feedback; only talk about the code that the developer is submitting for review. Criticism of the code is much harder to take personally because you are simply talking about the code, an objective thing, and not the developer. Again, this will improve the acceptance (as long as the developer understands that they are not their code).\r\n\r\n10. Non-Judgmental Collaboration\r\nThe whole team’s attitude and behavior should embrace non-judgmental collaboration, with the common goal of learning and sharing; regardless of experience level.\r\n\r\n\r\n11. Accept There Are Different Solutions\r\nKeep in mind that there are always different solutions to a problem. Most likely you have a favorite solution, but the developer’s solution may also be valid. Distinguish between common best practices and personal taste. Remember that skepticism may just reflect personal taste and not incorrect code.\r\n\r\n12. Remember Praise\r\nIt is totally acceptable to say: “Everything is good!”. No code changes is a valid outcome for a code review. Do not feel forced to find something wrong with the code.\r\n\r\nAnd last, but not least: do not forget to express appreciation if the code is good. Praising never hurts and may motivate the developer.\r\n\r\n13. Who Should Review?\r\nIt is my humble opinion that everyone on the team should be included on the code reviews. Simply from a learning perspective, every team member gets to see the release descriptions at a minimum. I got to the point when in a hurry where I would simply check the comments made across reviews throughout the day. By watching I was able to see what changes were occurring. When I had more time, I was an active reviewer trying to help make the codebase better, one comment at a time.\r\n\r\n14. Foster a Positive Code Review Culture\r\nCode reviews done by peers can put a strain on interpersonal team relationships. It is difficult to have work critiqued by peers. Therefore, in order for a peer code review to be successful, it’s extremely important that managers create a culture of collaboration and learning in the code review process.\r\n\r\nWhile it’s easy to see an identified defect as purely negative, each bug found is actually an opportunity for the team to improve code quality. Code reviews also allow junior team members to learn from senior leaders and for even the most experienced programmers to break bad habits.\r\n\r\nDefects found in a code review should not be used to evaluate team members. If review metrics become a basis for compensation or promotion, developers will become hostile toward the process and naturally focus on improving personal metrics rather than writing better overall code.\r\n\r\n15. Embrace the Subconscious Implications of a Code Review\r\nThe knowledge that someone else will be examining their work naturally drives people to produce a better product. This “Ego Effect” naturally incentivizes developers to write cleaner code because their peers will certainly see it. If your code is going to be reviewed, that is quite simply an incentive to double-check your work.\r\n\r\n16. Conclusions\r\nCode reviews are a powerful means to achieve higher quality code, establish best practices, and spread experience and knowledge. It also lets developers learn from their peers, practice mentorship, and engage in open dialog and discussion about what they build.\r\n\r\nTo be most successful, code reviews require a certain mindset and phrasing. Thus, it is supremely important to pay attention to the human aspects of a code review.\r\n\r\n— 0o0 —\r\n\r\nAs one of leading software development outsourcing companies in Vietnam, Titan Technology always use cutting-edge technologies to deliver all the best outcomes to our partners in over the world along with providing above good environments for any developer will need to explore themselves in this market.\r\n\r\nIn case you just grew your interest in working with Titan Technology, we are opening for many positions that suit with all your potential.\r\nFor your own feeling about Titan, feel free to check our website and submit your CV to us if you already have interest to become a Titaner :\r\n\r\nGet inspired with Titan’s environment here: https://www.titancorpvn.com\r\nReach to our incredible Recruitment Team: recruitment@titancorpvn.com\r\nSource: By Bob Fornal",
                Author="Admin",
                Image="https://blog.titancorpvn.com/wp-content/uploads/2021/03/A-Practical-Guide-to-Better-Code-Reviews-01.jpg",
                PostTypeID=postTypes.Single(i => i.Title == "BLOGS")._id,
                Url="https://blog.titancorpvn.com/a-practical-guide-to-better-code-reviews/",
                CreateAt=DateTime.Now,
                },
            };

            foreach (var post in posts)
            {
                context.Posts.Add(post);
            }
            context.SaveChanges();
        }
    }
}
