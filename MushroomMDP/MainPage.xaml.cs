using MushroomMDP.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MushroomMDP
{
    public partial class MainPage : MasterDetailPage
    {
        string[] mushroomTitles = new string[] { 
            "Мухомор", 
            "Боровик",
            "Лисички",
            "Вешенка",
            "Рыжик",
            "Опята",
            "Моховик",
            "Сыроежка",
            "Трутовик",
            "Трюфель",
        };

        string[] mushroomDescriptions = new string[]
        {
            "Ядовитый гриб с красной в белых крапинках шляпкой.",
            "Гриб с темнокоричневой толстой шляпкой и беловатой толстой ножкой; белый гриб.",
            "Вид грибов семейства лисичковых. Растет в Европе от Скандинавии до Средиземноморского бассейна, в основном в лиственных и хвойных лесах. Гриб легко обнаружить и распознать в природе.",
            "Род грибов семейства вёшенковые, или плевротовые (Pleurotaceae). Развивается на субстрате из неживых растительных остатков, из которого способен усваивать целлюлозу и лигнин. В природе растёт на стволах засохших деревьев.",
            "Рыжики отличаются общей жёлто-розовой или оранжево-красной окраской плодовых тел и наличием млечного сока, также окрашенного в оттенки красного цвета.",
            "Название происходит от характерного местообитания этих грибов: большинство их растёт на живой и отмершей древесине, на пнях. Опёнок луговой обитает совсем в других условиях, но плодовые тела его внешне схожи с опятами.",
            "Род съедобных трубчатых грибов семейства Болетовые (Boletaceae). Своё название получил из-за частого произрастания плодовых тел во мху.",
            "Съедобный гриб с хрупкой шляпкой, имеющий обычно красную, розовую, зелёную или желтоватую окраску.",
            "Несистематическая группа грибов отдела базидиомицеты. Трутовиками называют грибы, развивающиеся обычно на древесине, реже на почве, с трубчатым гименофором, с плодовыми телами распростёртыми, сидячими или шляпконожечными, с консистенцией мякоти от мясистой до жёсткой.",
            "Род сумчатых грибов с подземными клубневидными мясистыми плодовыми телами из порядка пецицевых. К данному роду относятся съедобные виды, считающиеся ценными деликатесами. «Трюфелями» часто называют и другие грибы с похожими плодовыми телами.",
        };

        string[] mushroomImageUrls = new string[]
        {
            "https://upload.wikimedia.org/wikipedia/commons/thumb/3/37/Amanita_muscaria_%28round_cap%29.jpg/1200px-Amanita_muscaria_%28round_cap%29.jpg",
            "https://o-prirode.ru/wp-content/uploads/2017/07/borovik-e1500975262900.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/9/9a/Chanterelle_Cantharellus_cibarius.jpg",
            "https://mycology.su/wp-content/uploads/2010/09/Pleurotus-ostreatus-2015-09-18-IMG_2942.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/8/89/Lactarius_deliciosus.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/f/fd/Armillaria_mellea_031005w.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/0/05/Xerocomus_chrysenteron1.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/8/84/Russula_betularum_01.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1b/Velvet_Revolver.jpg/1200px-Velvet_Revolver.jpg",
            "https://static.dw.com/image/55037013_401.jpg"
        };

        string[] mushroomWikiUrls = new string[]
        {
            "https://ru.wikipedia.org/wiki/Мухомор",
            "https://ru.wikipedia.org/wiki/Боровик",
            "https://ru.wikipedia.org/wiki/Лисичка_обыкновенная",
            "https://ru.wikipedia.org/wiki/Вёшенка",
            "https://ru.wikipedia.org/wiki/%D0%A0%D1%8B%D0%B6%D0%B8%D0%BA_(%D0%B3%D1%80%D0%B8%D0%B1)",
            "https://ru.wikipedia.org/wiki/%D0%9E%D0%BF%D1%91%D0%BD%D0%BE%D0%BA",
            "https://ru.wikipedia.org/wiki/%D0%9C%D0%BE%D1%85%D0%BE%D0%B2%D0%B8%D0%BA",
            "https://ru.wikipedia.org/wiki/%D0%A1%D1%8B%D1%80%D0%BE%D0%B5%D0%B6%D0%BA%D0%B0",
            "https://ru.wikipedia.org/wiki/%D0%A2%D1%80%D1%83%D1%82%D0%BE%D0%B2%D0%B8%D0%BA%D0%B8",
            "https://ru.wikipedia.org/wiki/%D0%9C%D1%83%D1%85%D0%BE%D0%BC%D0%BE%D1%80",
        };

        bool[] mushroomIsToxic = new bool[] { true, false, false, false, false, false, false, false, false, false };

        public MainPage()
        {
            InitializeComponent();
            aboutList.ItemsSource = GetMenuList();
            Detail = new NavigationPage(new HomePage());
            IsPresented = false;
        }

        private void aboutList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedMenuItem = e.SelectedItem as Mushroom;
            var selectedPage = selectedMenuItem.TargetPage;
            Detail = new NavigationPage(selectedPage);
            IsPresented = false;
        }

        private List<Mushroom> GetMenuList()
        {
            List<Mushroom> mushroomList = new List<Mushroom>();
            for (int i = 0; i < mushroomTitles.Length; i++)
            {
                var mushroom = new Mushroom()
                {
                    Title = mushroomTitles[i],
                    Description = mushroomDescriptions[i],
                    Image = ImageSource.FromUri(new Uri(mushroomImageUrls[i])),
                    WikiUri = mushroomWikiUrls[i],
                    Toxic = mushroomIsToxic[i]
                };
                var currentPage = new AboutPage(mushroom);
                mushroom.TargetPage = currentPage;
                mushroomList.Add(mushroom);
            }
            return mushroomList;
        }

        private void LoadPicture(string uri)
        {
            throw new NotImplementedException();
        }
    }
}
