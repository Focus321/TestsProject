using System.Collections.Generic;
using System.Linq;
using Data_Access_Layer.Models;

namespace Data_Access_Layer.Context.Initializer
{
    public static class TestingInitializer
    {
        public static void Initialize(TestingDB context)
        {
            context.Database.EnsureCreated();
            if (context.Tests.Any()) return;

            context.Teachers.Add(new Teacher()
            {
                FullName = "Teacher 1",
                Subject = "Астрономия",
                Login = "1",
                Password = "1"
            });

            context.Teachers.Add(new Teacher()
            {
                FullName = "Teacher 2",
                Subject = "Программирование",
                Login = "2",
                Password = "2"
            });

            context.SaveChanges();

            //Astronomy Test
            #region
            context.Tests.Add(new Test()
            {
                ImagePath = @"http://www.intellect-tour.ru/user_files/upload/images/%5EEC057B1397A71B0BEC3D01A74EF89BC72DCD5E0C00C47999A1%5Epimgpsh_fullsize_distr.jpg",
                TestName = "ТЕСТ ПО АСТРОНОМИИ",
                NumberOfAttempts = 5,
                TeacherId = context.Teachers.First(x => x.FullName == "Teacher 1").Id,
                Questions = new List<Question>()
                {
                    new Question()
                    {
                        ImagePath= @"https://hi-news.ru/wp-content/uploads/2020/02/space_060241612.jpg",
                        QuestionText="Самый большой спутник в Солнечной системе?",
                        Appraisal=1,
                        Answers=new List<Answer>()
                        {
                            new Answer()
                            {
                                ResponseText="Ио",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Луна",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Ганимед",
                                Right=true
                            },
                            new Answer()
                            {
                                ResponseText="Европа",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Фобос",
                                Right=false
                            }
                        }
                    },
                    new Question()
                    {
                        ImagePath= @"https://s.hi-news.ru/wp-content/uploads/2015/09/sun_sistem_01-750x461.jpg",
                        QuestionText="Ближайшая к Солнцу планета?",
                        Appraisal=1,
                        Answers=new List<Answer>()
                        {
                            new Answer()
                            {
                                ResponseText="Венера",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Уран",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Ганимед",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Земля",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Юпитер",
                                Right=false
                            },
                             new Answer()
                            {
                                ResponseText="Марс",
                                Right=false
                            },
                              new Answer()
                            {
                                ResponseText="Меркурий",
                                Right=true
                            }
                        }
                     },
                    new Question()
                     {
                        ImagePath="https://cdn-tn.fishki.net/20/upload/post/2016/09/29/2089878/tn/favewallpapers.jpg",
                        QuestionText="Самая большая планета Солнечной системы?",
                        Appraisal=1,
                        Answers=new List<Answer>()
                        {
                             new Answer()
                            {
                                ResponseText="Юпитер",
                                Right=true
                            },
                            new Answer()
                            {
                                ResponseText="Уран",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Нептун",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Плутон",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Церера",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Земля",
                                Right=false
                            },
                             new Answer()
                             {
                                ResponseText="Юпитер",
                                Right=true
                             }
                        }
                     },
                    new Question()
                    {
                        ImagePath="https://i.ytimg.com/vi/2jQ3W-Ig-z8/maxresdefault.jpg",
                        QuestionText="Облако Оорта – это?",
                        Appraisal=1,
                        Answers=new List<Answer>()
                        {
                             new Answer()
                            {
                                ResponseText="Сферическая область солнечной системы",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Самый большой ураган на Юпитере",
                                Right=true
                            },
                            new Answer()
                            {
                                ResponseText="Грозовой фрон на Венере",
                                Right=false
                            }
                        }
                    },
                    new Question()
                    {
                        ImagePath="https://new-science.ru/wp-content/uploads/2020/02/5385-11.jpg",
                        QuestionText="Солнце – типичный представитель этого класса звезд",
                        Appraisal=1,
                        Answers=new List<Answer>()
                        {
                             new Answer()
                            {
                                ResponseText="Желтый карлик",
                                Right=true
                            },
                            new Answer()
                            {
                                ResponseText="Белый карлик",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Голубой карлик",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Красгый гигант",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Пульсар",
                                Right=false
                            }
                        }
                    },
                    new Question()
                    {
                        ImagePath="https://spaceworlds.ru/wp-content/uploads/2018/12/poyas-Kojpera1.jpeg",
                        QuestionText="Крупнейший известный объект пояса Койпера?",
                        Appraisal=1,
                        Answers=new List<Answer>()
                        {
                             new Answer()
                            {
                                ResponseText="Плутон",
                                Right=true
                            },
                            new Answer()
                            {
                                ResponseText="Церера",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Макемаке",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Седна",
                                Right=false
                            }
                        }
                    },
                    new Question()
                    {
                        ImagePath="https://in-space.ru/wp-content/uploads/2015/09/test_solnechnaya_sistema-1024x640.jpg",
                        QuestionText="Эта планета могла стать звездой, но не набрала достаточно массы",
                        Appraisal=1,
                        Answers=new List<Answer>()
                        {
                             new Answer()
                            {
                                ResponseText="Меркурий",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Нептун",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Сатурн",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Юпитер",
                                Right=true
                            }
                        }
                    },
                    new Question()
                    {
                        ImagePath="https://militaryarms.ru/wp-content/uploads/2019/05/kometa-galleya.jpg",
                        QuestionText="Комета Галлея появляется в небе Земли с периодичностью?",
                        Appraisal=1,
                        Answers=new List<Answer>()
                        {
                             new Answer()
                            {
                                ResponseText="Каждые 15-16 лет",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Каждые 75-76 лет",
                                Right=true
                            },
                            new Answer()
                            {
                                ResponseText="Каждые 140-145 лет",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Ежегодно",
                                Right=false
                            }
                        }
                    },
                    new Question()
                    {
                        ImagePath="https://upload.wikimedia.org/wikipedia/commons/thumb/d/d4/Johannes_Kepler_1610.jpg/200px-Johannes_Kepler_1610.jpg",
                        QuestionText="Первооткрывателем законов движения планет Солнечной системы был",
                        Appraisal=1,
                        Answers=new List<Answer>()
                        {
                             new Answer()
                            {
                                ResponseText="Николай Коперник",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Иоганн Кеплер",
                                Right=true
                            },
                            new Answer()
                            {
                                ResponseText="Джордано Бруно",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Жак Кассини",
                                Right=false
                            }
                        }
                    }
                }
            });
            #endregion

            //Programming Test 
            #region
            context.Tests.Add(new Test()
            {
                ImagePath = @"https://d2qc4bb64nav1a.cloudfront.net/cdn/13/images/20150902095656vlbuif.jpg",
                TestName = "ТЕСТ ПО С#",
                NumberOfAttempts = 5,
                TeacherId = context.Teachers.First(x => x.FullName == "Teacher 2").Id,
                Questions = new List<Question>()
                {
                    new Question()
                    {
                        ImagePath= @"https://d2qc4bb64nav1a.cloudfront.net/cdn/13/images/20150902095656vlbuif.jpg",
                        QuestionText="С# — это",
                        Appraisal=1,
                        Answers=new List<Answer>()
                        {
                            new Answer()
                            {
                                ResponseText="Набор символов",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Объектно-ориентированный язык программирования для разработки приложений для платформы Microsoft .NET Framework",
                                Right=true
                            },
                            new Answer()
                            {
                                ResponseText="Мультипарадигменный язык программирования",
                                Right=false
                            }
                        }
                    },
                    new Question()
                    {
                        ImagePath= @"https://cdn.proghub.ru/t/oop.png",
                        QuestionText="Принципы ООП в C#",
                        Appraisal=1,
                        Answers=new List<Answer>()
                        {
                            new Answer()
                            {
                                ResponseText="Инкапсуляция, полиморфизм, наследование, обстракция",
                                Right=true
                            },
                            new Answer()
                            {
                                ResponseText="Их нет",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Инкапсуляция, полиморфизм, наследование",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Инкапсуляция, наследование, обстракция",
                                Right=false
                            }
                        }
                    },
                    new Question()
                    {
                        ImagePath= @"https://visualstudiomagazine.com/-/media/ECG/redmondmag/Images/IntroImagesBigSmall/BlueGreenCircuts.jpg",
                        QuestionText="Полиморфизм — это",
                        Appraisal=1,
                        Answers=new List<Answer>()
                        {
                            new Answer()
                            {
                                ResponseText="Копирование полей и методов",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Механизм, позволяющий описать новый класс на основе цже существующего",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Это возможность объектов с одинаковой спецификацией иметь разную реализацию",
                                Right=true
                            },
                            new Answer()
                            {
                                ResponseText="Механизм, позволяющий скрыть поля и методы класса",
                                Right=false
                            }
                        }
                    },
                    new Question()
                    {
                        ImagePath= @"https://www.puntonetformazione.com/wp-content/uploads/2017/06/corso-c.jpg",
                        QuestionText="Upcast — это",
                        Appraisal=1,
                        Answers=new List<Answer>()
                        {
                            new Answer()
                            {
                                ResponseText="Это приведение объекта класса производного типа к базовому типу",
                                Right=true
                            },
                            new Answer()
                            {
                                ResponseText="Это приведение экземпляра класса базового типа к производному",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Проверка совместимости объектов с задаными типами",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Передача данных от одного объекта другому",
                                Right=false
                            }
                        }
                    },
                    new Question()
                    {
                        ImagePath= @"https://cdn.proghub.ru/t/oop.png",
                        QuestionText="Как расшифровывается ООП",
                        Appraisal=1,
                        Answers=new List<Answer>()
                        {
                            new Answer()
                            {
                                ResponseText="Осторожно, острый паркет",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Объедки Отца Первого",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Общественно опасные последствия",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Объектно-ориентированное программирование",
                                Right=true
                            }
                        }
                    },
                    new Question()
                    {
                        ImagePath= @"https://images.techhive.com/images/article/2016/10/code-459070_1280-100690667-large.jpg",
                        QuestionText="Что из этого возможно?",
                        Appraisal=1,
                        Answers=new List<Answer>()
                        {
                            new Answer()
                            {
                                ResponseText="multix2=(x)=>{return x*2;}",
                                Right=true
                            },
                            new Answer()
                            {
                                ResponseText=">multix2=x=>x*2;",
                                Right=true
                            },
                            new Answer()
                            {
                                ResponseText="multix2=delegate(int x){return x*2;}",
                                Right=true
                            }
                        }
                    },
                    new Question()
                    {
                        ImagePath= @"https://files.virgool.io/upload/users/73758/posts/h00jjlau5epu/su6tl3vi8qct.png",
                        QuestionText="WPF. Потдерживаемые механизмы ",
                        Appraisal=1,
                        Answers=new List<Answer>()
                        {
                            new Answer()
                            {
                                ResponseText="Аниация, аудио, видео.",
                                Right=true
                            },
                            new Answer()
                            {
                                ResponseText="Стили, шаблоны, команды",
                                Right=true
                            },
                            new Answer()
                            {
                                ResponseText="Много функциональная модель рисования, web-подобная модель компоновки",
                                Right=true
                            }
                        }
                    },
                    new Question()
                    {
                        ImagePath= @"https://itvdn.blob.core.windows.net/catalog-images/csharp-essential-img.jpg",
                        QuestionText="Ковариантность — это",
                        Appraisal=1,
                        Answers=new List<Answer>()
                        {
                            new Answer()
                            {
                                ResponseText="Это возможность приведения массива классов наследников к своим базовым интерфейсам",
                                Right=true
                            },
                            new Answer()
                            {
                                ResponseText="Это возможность приведения массива базовых типов к массивам производным",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Это создание массивов",
                                Right=false
                            },
                            new Answer()
                            {
                                ResponseText="Что-то связаное с массивами",
                                Right=false
                            }
                        }
                }
                }
            });
            #endregion

            context.SaveChanges();
        }
    }
}