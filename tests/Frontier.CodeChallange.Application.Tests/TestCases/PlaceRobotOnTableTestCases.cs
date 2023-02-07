using Frontier.CodeChallange.Application.Entities;
using Frontier.CodeChallange.Application.Enums;
using Frontier.CodeChallange.Application.Tests.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontier.CodeChallange.Application.Tests.TestCases
{
    class PlaceRobotOnTableTestCases : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return GetNotMatchedTestCase();
            yield return GetPlaceOutOfRangeTestCase();
            yield return GetNormalTestCase();

        }

        private object[] GetNormalTestCase()
        {
            return new object[]
           {
                new PlaceRobotOnTableTestCase
                {
                    InputCommand = "PLACE(1,1,EAST)",
                    IsPlacedOnTable = false,
                    TableWidth = 5,
                    ExpectedReponse = new CommandResponse
                    {
                        Status = ResponseStatus.Success
                    },
                    TestName = "Normal Command should work"
                }
           };
        }

        private object[] GetPlaceOutOfRangeTestCase()
        {
            return new object[]
            {
                new PlaceRobotOnTableTestCase
                {
                    InputCommand = "PLACE(6,1,EAST)",
                    IsPlacedOnTable = false,
                    TableWidth = 5,
                    ExpectedReponse = new CommandResponse
                    {
                        Status = ResponseStatus.Ignore,
                        Message = "Blocked"
                    },
                    TestName = "Command should be ignored when position is not valid"
                }
            };
        }

        /// <summary>
        /// You could not use PLACE X,Y,DIRECTION again when robot on table
        /// </summary>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <remarks>we could add this unit test later if needed</remarks>
        //private object[] GetRobotOnTableTestCase()
        //{
        //    return new object[]
        //    {
        //        new PlaceRobotOnTableTestCase
        //        {
        //            InputCommand = "PLACE(1,1,EAST)",
        //            IsPlacedOnTable = true,
        //            TableWidth = 5,
        //            ExpectedReponse = new CommandResponse
        //            {
        //                Status = ResponseStatus.Fail,
        //                Message = "This command could not be used"
        //            },
        //            TestName = "Could not use full place command again"
        //        }
        //    };
        //}

        private object[] GetNotMatchedTestCase()
        {
            return new object[]
            {
                new PlaceRobotOnTableTestCase
                {
                    InputCommand = "this is a test",
                    IsPlacedOnTable = false,
                    TableWidth = 5,
                    ExpectedReponse = new CommandResponse
                    {
                        Status = ResponseStatus.Fail,
                        Message = "Command not match"
                    },
                    TestName = "Not Matched command should fail"
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
