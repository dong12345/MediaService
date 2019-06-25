using MediaService.Common;
using MediaService.DBModel;
using MediaService.MediaDBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaService.Service
{
    public class MediaServices
    {
        private MyContext _context;
        private DbContextOptionsBuilder<MyContext> _options;
        private int count = 0;
        private string msg = string.Empty;
        private bool isSuccess = false;
        public MediaServices(DbContextOptionsBuilder<MyContext> options, string _sql)
        {
            _options = options;
            options.UseNpgsql(_sql);
        }



        #region FormPublic(会刊)

        /// <summary>
        /// 创建会刊
        /// </summary>
        /// <returns></returns>
        public async Task<ModifyReplyModel> CreateFormPublicInfo(FormPublic formPublic)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    await _context.FormPublic.AddAsync(formPublic);
                    count = await _context.SaveChangesAsync();
                    if (count > 0)
                    {
                        msg = "创建成功";
                        isSuccess = true;
                    }
                    else
                    {
                        msg = "创建失败";
                    }

                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.InnerException.Message, count);
            }
        }

        /// <summary>
        /// 修改会刊信息
        /// </summary>
        /// <param name="formPublic"></param>
        /// <returns></returns>
        public async Task<ModifyReplyModel> UpdateFormPublicInfo(FormPublic formPublic)
        {
            try
            {
                using (_context = new MyContext(_options.Options))
                {
                    string idString = formPublic.Id.ToString();
                    var modified_model = GetFormPublicInfoByIdInside(idString);
                    if (modified_model == null)
                    {
                        msg = "当前实例不存在";
                    }
                    else
                    {
                        #region 修改
                        modified_model.Address = formPublic.Address;
                        modified_model.AddressEn = formPublic.AddressEn;
                        modified_model.BoothNumber = formPublic.BoothNumber;
                        modified_model.CompanyId = formPublic.CompanyId;
                        modified_model.CompanyNameCn = formPublic.CompanyNameCn;
                        modified_model.CompanyNameEn = formPublic.CompanyNameEn;
                        modified_model.Description = formPublic.Description;
                        modified_model.DescriptionEn = formPublic.DescriptionEn;
                        modified_model.Email = formPublic.Email;
                        modified_model.Fax = formPublic.Fax;
                        modified_model.IsHaveLogo = formPublic.IsHaveLogo;
                        modified_model.IsPay = formPublic.IsPay;
                        modified_model.Option = formPublic.Option;
                        modified_model.Logo = formPublic.Logo;
                        modified_model.OwnerId = formPublic.OwnerId;
                        modified_model.OwnerName = formPublic.OwnerName;
                        modified_model.PavilionNumber = formPublic.PavilionNumber;
                        modified_model.SnecLogoWebsite = formPublic.SnecLogoWebsite;
                        modified_model.Telephone = formPublic.Telephone;
                        modified_model.Updated_at = DateTime.Now.ToString();
                        modified_model.Website = formPublic.Website;
                        #endregion
                        count = await _context.SaveChangesAsync();
                        if (count > 0)
                        {
                            isSuccess = true;
                            msg = "修改成功";
                        }
                        else
                        {
                            msg = "修改失败";
                        }
                    }
                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.Message, count);
            }
        }

        /// <summary>
        /// 根据Id删除会刊信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ModifyReplyModel> DeleteFormPublicInfoById(string id)
        {
            try
            {
                using (_context = new MyContext(_options.Options))
                {
                    var model = GetFormPublicInfoByIdInside(id);
                    if (model == null)
                    {
                         msg = "数据库中没有id为" + id + "的实例可以删除！";
                    }
                    else
                    {
                        _context.FormPublic.Remove(model);
                        count = await _context.SaveChangesAsync();
                        if (count > 0)
                        {
                            msg = "删除成功";
                            isSuccess = true;
                        }
                        else
                        {
                            msg = "删除失败";
                        }
                    }
                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.Message, count);
            }
        }


        /// <summary>
        /// 获得会刊信息列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<FormPublic>> GetFormPublicInfoList()
        {
            try
            {
                using (_context = new MyContext(_options.Options))
                {
                    var list = await _context.FormPublic.ToListAsync();
                    return list;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
        }

        /// <summary>
        /// 根据Id获得会刊信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<FormPublic> GetFormPublicInfoById(string id)
        {
            try
            {
                using (_context = new MyContext(_options.Options))
                {
                    Guid gid = new Guid(id);
                    var item = await _context.FormPublic
                            .FirstOrDefaultAsync(x => x.Id == gid);
                    return item;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
        }

        /// <summary>
        /// 根据条件查询会刊信息列表(带分页)
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public async Task<List<FormPublic>> GetFormPublicList(int pageindex, int pagesize, SearchModel searchModel)
        {
            try
            {
                using (_context = new MyContext(_options.Options))
                {
                    var list = await _context.FormPublic
                        .Where(x => (string.IsNullOrEmpty(searchModel.CompanyName) || x.CompanyNameCn.Contains(searchModel.CompanyName) || x.CompanyNameEn.Contains(searchModel.CompanyName))
                                    && (string.IsNullOrEmpty(searchModel.ContractNumber) || x.ContractNumber.Contains(searchModel.ContractNumber))
                                    && (string.IsNullOrEmpty(searchModel.PavilionNumber) || x.PavilionNumber.Contains(searchModel.PavilionNumber))
                                    && (string.IsNullOrEmpty(searchModel.BoothNumber) || x.BoothNumber.Contains(searchModel.BoothNumber))
                                    && (searchModel.IsPay == x.IsPay)
                                    && (string.IsNullOrEmpty(searchModel.OwnerId) || x.OwnerId == searchModel.OwnerId)
                                    && (string.IsNullOrEmpty(searchModel.Begin_date) || x.Created_at >= Convert.ToDateTime(searchModel.Begin_date))
                                    && (string.IsNullOrEmpty(searchModel.End_date) || x.Created_at <= Convert.ToDateTime(searchModel.Begin_date)))
                        .OrderByDescending(x => x.Created_at)
                        .Skip(((pageindex - 1) * pagesize))
                        .Take(pagesize)
                        .ToListAsync();

                    return list;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
        }

        /// <summary>
        /// 根据条件查询会刊信息总数
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public async Task<int> GetFormPublicListCount(SearchModel searchModel)
        {
            var total = 0;
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    var list = await _context.FormPublic.ToListAsync();
                    if (searchModel != null)
                    {
                        total = list
                           .Where(x => (string.IsNullOrEmpty(searchModel.CompanyName) || x.CompanyNameCn.Contains(searchModel.CompanyName) || x.CompanyNameEn.Contains(searchModel.CompanyName))
                                    && (string.IsNullOrEmpty(searchModel.ContractNumber) || x.ContractNumber.Contains(searchModel.ContractNumber))
                                    && (string.IsNullOrEmpty(searchModel.PavilionNumber) || x.PavilionNumber.Contains(searchModel.PavilionNumber))
                                    && (string.IsNullOrEmpty(searchModel.BoothNumber) || x.BoothNumber.Contains(searchModel.BoothNumber))
                                    && (searchModel.IsPay == x.IsPay)
                                    && (string.IsNullOrEmpty(searchModel.OwnerId) || x.OwnerId == searchModel.OwnerId)
                                    && (string.IsNullOrEmpty(searchModel.Begin_date) || x.Created_at >= Convert.ToDateTime(searchModel.Begin_date))
                                    && (string.IsNullOrEmpty(searchModel.End_date) || x.Created_at <= Convert.ToDateTime(searchModel.Begin_date)))
                            .Count();
                    }
                    else
                    {
                        total = list.Count();
                    }
                }


            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
            return total;
        }

        /// <summary>
        /// 根据Id获取会刊信息(内部调用)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FormPublic GetFormPublicInfoByIdInside(string id)
        {
            try
            {
                Guid gid = new Guid(id);
                var item = _context.FormPublic
                    .FirstOrDefault(x => x.Id == gid);
                return item;
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }

        }


        #endregion

        #region Express(快递单)

        /// <summary>
        /// 创建快递单记录
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        public async Task<ModifyReplyModel> CreateExpressInfo(Express express)
        {
            try
            {
                using (_context = new MyContext(_options.Options))
                {
                    await _context.Express.AddAsync(express);
                    count = await _context.SaveChangesAsync();
                    if (count > 0)
                    {
                        isSuccess = true;
                        msg = "创建成功";
                    }
                    else
                    {
                        msg = "创建失败";
                    }
                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.Message, count);
            }
        }

        /// <summary>
        /// 修改快递单记录
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        public async Task<ModifyReplyModel> UpdateExpressInfo(Express express)
        {
            try
            {
                using (_context = new MyContext(_options.Options))
                {
                    string idString = express.Id.ToString();
                    var model = GetExpressInfoByIdInside(idString);
                    if (model == null)
                    {
                        msg = "当前实例不存在";
                    }
                    else
                    {
                        model.Address = express.Address;
                        model.ExpressCompany = express.ExpressCompany;
                        model.ExpressContent = express.ExpressContent;
                        model.ExpressNum = express.ExpressNum;
                        model.IsExamine = express.IsExamine;
                        model.IsSend = express.IsSend;
                        model.Price = express.Price;
                        model.Recipient = express.Recipient;
                        model.RecipientUnit = express.RecipientUnit;
                        model.Sender = express.Sender;
                        model.SentDate = express.SentDate;
                        model.Tel = express.Tel;

                        count = await _context.SaveChangesAsync();
                        if (count > 0)
                        {
                            isSuccess = true;
                            msg = "修改成功";
                        }
                        else
                        {
                            msg = "修改失败";
                        }
                    }
                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.Message, count);
            }
        }

        /// <summary>
        /// 根据Id获取快递单信息(内部调用)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Express GetExpressInfoByIdInside(string id)
        {
            try
            {
                Guid gid = new Guid(id);
                var item = _context.Express
                    .FirstOrDefault(x => x.Id == gid);
                return item;
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }

        }

        /// <summary>
        /// 根据Id删除快递单记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ModifyReplyModel> DeleteExpressInfoById(string id)
        {
            try
            {
                using (_context = new MyContext(_options.Options))
                {
                    var model = GetExpressInfoByIdInside(id);
                    if (model == null)
                    {
                        msg = "数据库中没有id为"+id+"的实例可以删除！";
                    }
                    else
                    {
                        _context.Express.Remove(model);
                        count = await _context.SaveChangesAsync();
                        if (count > 0)
                        {
                            msg = "删除成功";
                            isSuccess = true;
                        }
                        else
                        {
                            msg = "删除失败";
                        }
                    }
                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.Message, count);
            }
        }

        /// <summary>
        /// 根据Id获得快递单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Express> GetExpressInfoById(string id)
        {
            try
            {
                using (_context = new MyContext(_options.Options))
                {
                    Guid gid = new Guid(id);
                    var item = await _context.Express
                            .FirstOrDefaultAsync(x => x.Id == gid);
                    return item;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
        }

        /// <summary>
        /// 根据条件查询快递单信息列表(带分页)
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public async Task<List<Express>> GetExpressList(int pageindex, int pagesize, SearchModel searchModel)
        {
            try
            {
                using (_context = new MyContext(_options.Options))
                {
                    var list = await _context.Express
                       .Where(x=>(string.IsNullOrEmpty(searchModel.ExpressNum) || x.ExpressNum.Contains(searchModel.ExpressNum))
                        && (string.IsNullOrEmpty(searchModel.Sender) || x.Sender.Contains(searchModel.Sender))
                        && (string.IsNullOrEmpty(searchModel.Begin_date) || x.SentDate>=Convert.ToDateTime(searchModel.Begin_date))
                        && (string.IsNullOrEmpty(searchModel.End_date) ||x.SentDate<=Convert.ToDateTime(searchModel.End_date))
                        && (string.IsNullOrEmpty(searchModel.Recipient) || x.Recipient.Contains(searchModel.Recipient))
                        && (string.IsNullOrEmpty(searchModel.RecipientUnit) || x.RecipientUnit.Contains(searchModel.RecipientUnit)))
                        .OrderByDescending(x => x.Created_at)
                        .Skip(((pageindex - 1) * pagesize))
                        .Take(pagesize)
                        .ToListAsync();

                    return list;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
        }


        /// <summary>
        /// 根据条件查询快递单信息总数
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public async Task<int> GetExpressListCount(SearchModel searchModel)
        {
            var total = 0;
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    //var list = await _context.Express.ToListAsync();
                    //if (searchModel != null)
                    //{
                    //    total = list
                    //      .Where(x => (string.IsNullOrEmpty(searchModel.ExpressNum) || x.ExpressNum.Contains(searchModel.ExpressNum))
                    //    && (string.IsNullOrEmpty(searchModel.Sender) || x.Sender.Contains(searchModel.Sender))
                    //    && (string.IsNullOrEmpty(searchModel.Begin_date) || x.SentDate >= Convert.ToDateTime(searchModel.Begin_date))
                    //    && (string.IsNullOrEmpty(searchModel.End_date) || x.SentDate <= Convert.ToDateTime(searchModel.End_date))
                    //    && (string.IsNullOrEmpty(searchModel.Recipient) || x.Recipient.Contains(searchModel.Recipient))
                    //    && (string.IsNullOrEmpty(searchModel.RecipientUnit) || x.RecipientUnit.Contains(searchModel.RecipientUnit)))
                    //        .Count();
                    //}
                    //else
                    //{
                    //    total = list.Count();
                    //}

                    if (searchModel != null)
                    {
                        var list = await _context.Express
                            .Where(x => (string.IsNullOrEmpty(searchModel.ExpressNum) || x.ExpressNum.Contains(searchModel.ExpressNum))
                        && (string.IsNullOrEmpty(searchModel.Sender) || x.Sender.Contains(searchModel.Sender))
                        && (string.IsNullOrEmpty(searchModel.Begin_date) || x.SentDate >= Convert.ToDateTime(searchModel.Begin_date))
                        && (string.IsNullOrEmpty(searchModel.End_date) || x.SentDate <= Convert.ToDateTime(searchModel.End_date))
                        && (string.IsNullOrEmpty(searchModel.Recipient) || x.Recipient.Contains(searchModel.Recipient))
                        && (string.IsNullOrEmpty(searchModel.RecipientUnit) || x.RecipientUnit.Contains(searchModel.RecipientUnit)))
                        .ToListAsync();
                        total = list.Count();
                    }
                    else
                    {
                        var  list = await _context.Express.ToListAsync();
                        total = list.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
            return total;
        }
        #endregion


        /// <summary>
        /// 返回ModifyReplyModel对象
        /// </summary>
        /// <param name="success"></param>
        /// <param name="msg"></param>
        /// <param name="modified_count"></param>
        /// <returns></returns>
        private ModifyReplyModel GetModifyReply(bool success, string msg, int modified_count)
        {
            return new ModifyReplyModel() { success = success, modified_count = modified_count, msg = msg };
        }
    }
}
