using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDialogue
{
    private string[] dialogue = @"
    The view from the lighthouse excited even the most seasoned traveler.
    Standing on one's head at job interviews forms a lasting impression.
    The furnace repairman indicated the heating system was acting as an air conditioner.
    Three years later, the coffin was still full of Jello.
    The white water rafting trip was suddenly halted by the unexpected brick wall.
    He poured rocks in the dungeon of his mind.
    He was 100% into fasting with her until he understood that meant he couldn't eat.
    Combines are no longer just for farms.
    His thought process was on so many levels that he gave himself a phobia of heights.
    For some unfathomable reason, the response team didn't consider a lack of milk for my cereal as a proper emergency.
    I always dreamed about being stranded on a desert island until it actually happened.
    He played the game as if his life depended on it and the truth was that it did.
    It doesn't sound like that will ever be on my travel list.
    Please wait outside of the house.
    He had unknowingly taken up sleepwalking as a nighttime hobby.
    I'm not a party animal, but I do like animal parties.
    I cheated while playing the darts tournament by using a longbow.
    Two more days and all his problems would be solved.
    I’m working on a sweet potato farm.
    Every manager should be able to recite at least ten nursery rhymes backward.
    He stepped gingerly onto the bridge knowing that enchantment awaited on the other side.
    I made myself a peanut butter sandwich as I didn't want to subsist on veggie crackers.
    You've been eyeing me all day and waiting for your move like a lion stalking a gazelle in a savannah.
    Today arrived with a crash of my car through the garage door.
    He had a vague sense that trees gave birth to dinosaurs.
    Baby wipes are made of chocolate stardust.
    I am happy to take your donation; any amount will be greatly appreciated.
    He dreamed of eating green apples with worms.
    I know many children ask for a pony, but I wanted a bicycle with rockets strapped to it.
    Twin 4-month-olds slept in the shade of the palm tree while the mother tanned in the sun.
    Today I dressed my unicorn in preparation for the race.
    The fence was confused about whether it was supposed to keep things in or keep things out.
    He was sure the Devil created red sparkly glitter.
    Pat ordered a ghost pepper pie.
    He loved eating his bananas in hot dog buns.
    I only enjoy window shopping when the windows are transparent.
    Lucifer was surprised at the amount of life at Death Valley.
    The shooter says goodbye to his love.
    When I cook spaghetti, I like to boil it a few minutes past al dente so the noodles are super slippery.
    He wondered why at 18 he was old enough to go to war, but not old enough to buy cigarettes.
    Nudist colonies shun fig-leaf couture.
    She used her own hair in the soup to give it more flavor.
    As time wore on, simple dog commands turned into full paragraphs explaining why the dog couldn’t do something.
    He spiked his hair green to support his iguana.
    He took one look at what was under the table and noped the hell out of there.
    When he asked her favorite number, she answered without hesitation that it was diamonds.
    The Japanese yen for commerce is still well-known.
    Fluffy pink unicorns are a popular status symbol among macho men.
    There's a reason that roses have thorns.
    Having no hair made him look even hairier.
    There were white out conditions in the town; subsequently, the roads were impassable.
    The most exciting eureka moment I've had was when I realized that the instructions on food packets were just guidelines.
    The hawk didn’t understand why the ground squirrels didn’t want to be his friend.
    He set out for a short walk, but now all he could see were mangroves and water were for miles.
    In hopes of finding out the truth, he entered the one-room library.
    Red is greener than purple, for sure.
    The overpass went under the highway and into a secret world.
    Just because the water is red doesn't mean you can't drink it.
    They were excited to see their first sloth.
    His confidence would have bee admirable if it wasn't for his stupidity.
    He was sitting in a trash can with high street class.
    The father handed each child a roadmap at the beginning of the 2-day road trip and explained it was so they could find their way home.
    He felt that dining on the bridge brought romance to his relationship with his cat.
    Excitement replaced fear until the final moment.
    He fumbled in the darkness looking for the light switch, but when he finally found it there was someone already there.
    He created a pig burger out of beef.
    The lyrics of the song sounded like fingernails on a chalkboard.
    Sometimes you have to just give up and win by cheating.
    He wore the surgical mask in public not to keep from catching a virus, but to keep people away from him.
    She opened up her third bottle of wine of the night.
    Swim at your own risk was taken as a challenge for the group of Kansas City college students.
    He had a wall full of masks so she could wear a different face every day.
    She found his complete dullness interesting.
    Martha came to the conclusion that shake weights are a great gift for any occasion.
    He knew it was going to be a bad day when he saw mountain lions roaming the streets.
    Jerry liked to look at paintings while eating garlic ice cream.
    Please tell me you don't work in a morgue.
    The tears of a clown make my lipstick run, but my shower cap is still intact.
    The rusty nail stood erect, angled at a 45-degree angle, just waiting for the perfect barefoot to come along.
    Toddlers feeding raccoons surprised even the seasoned park ranger.
    The teenage boy was accused of breaking his arm simply to get out of the test.
    Despite what your teacher may have told you, there is a wrong way to wield a lasso.
    Every manager should be able to recite at least ten nursery rhymes backward.
    A song can make or ruin a person’s day if they let it get to them.
    He liked to play with words in the bathtub.
    Honestly, I didn't care much for the first season, so I didn't bother with the second.
    The miniature pet elephant became the envy of the neighborhood.
    The beauty of the African sunset disguised the danger lurking nearby.
    It didn't take long for Gary to detect the robbers were amateurs.
    He decided to count all the sand on the beach as a hobby.
    The Great Dane looked more like a horse than a dog.
    Her fragrance of choice was fresh garlic.
    The fifty mannequin heads floating in the pool kind of freaked them out.
    Nancy thought the best way to create a welcoming home was to line it with barbed wire.
    The elderly neighborhood became enraged over the coyotes who had been blamed for the poodle’s disappearance.
    His get rich quick scheme was to grow a cactus farm.
    He appeared to be confusingly perplexed.
    Flesh-colored yoga pants were far worse than even he feared.
    Love is not like pizza.
    Just go ahead and press that button.
    ".Split(".");

    public string getDialogue(){
        int random = Random.Range(0,dialogue.Length);
        return dialogue[random];
    }
}
